#include "WorkWithDatabase.h"

bool WorkWithDatabase::GetParameters(string incomingLine)
{
    prev = 0;
    while ((next = incomingLine.find(delim, prev))
        != string::npos) {
        // Отладка-start
        string tmp = incomingLine.substr(prev, next - prev);
        cout << tmp << endl;
        // Отладка-end
        incomingLineParameters.push_back(incomingLine.substr(prev, next - prev));
        prev = next + delta;
    }
    // Отладка-start
    string tmp = incomingLine.substr(prev);
    cout << tmp << endl;
    // Отладка-end
    incomingLineParameters.push_back(incomingLine.substr(prev));

    if (incomingLineParameters.size() >= 1) {
        return true;
    }
    else {
        return false;
    }
}

bool WorkWithDatabase::StringIsNumber(const std::string& s)
{
    string::const_iterator it = s.begin();
    // проверяем каждый символ в строке, чтобы вынести вердикт 
    while (it != s.end() && std::isdigit(*it) ||
        it != s.end() && (*it) == '.') ++it;
    return !s.empty() && it == s.end();
}

void WorkWithDatabase::DisplayError(SQLSMALLINT t, SQLHSTMT h) {
    numRecs = 0;
    SQLGetDiagField(t, h, 0, SQL_DIAG_NUMBER, &numRecs, 0, 0);
    /// Get the status records.
    i = 1;
    while (i <= numRecs && (returnCode = SQLGetDiagRec(t, h, i, SqlState, &NativeError,
        Msg, sizeof(Msg), &MsgLen)) != SQL_NO_DATA) {
        printf("Error %d: %s\n", NativeError, Msg);
        i++;
    }
}

BOOL WorkWithDatabase::AllocateHandlers()
{
    /* try Allocate an environment handle */
    rc = SQLAllocEnv(&hEnv);
    /* try Allocate a connection handle */
    rc = SQLAllocConnect(hEnv, &hDbc);
    /* try Connect to the database */
    rc = SQLDriverConnect(hDbc, NULL,
        (SQLCHAR*)connectionString,
        SQL_NTS, (SQLCHAR*)szConnStrOut,
        255, (SQLSMALLINT*)&iConnStrLength2Ptr, SQL_DRIVER_NOPROMPT);
    /* try Allocate a statement handle */
    rc = SQLAllocStmt(hDbc, &hStmt);
    // возвращаем результат операций
    return rc;
}

BOOL WorkWithDatabase::FreeHandlers()
{
    /* try Free an statement handle */
    rc = SQLFreeStmt(&hStmt, SQL_DROP);
    /* try disconnect */
    rc = SQLDisconnect(&hDbc);    
    /* try Free an connection handle */
    rc = SQLFreeHandle(SQL_HANDLE_DBC, &hDbc);
    /* try Free an environment handle */
    rc = SQLFreeHandle(SQL_HANDLE_ENV, &hEnv);
    // возвращаем результат операций
    return rc;
}

void WorkWithDatabase::RememberTableAnswer()
{
    rc = SQLNumResultCols(hStmt, &fieldCount);
    if (fieldCount > 0) {
        /* loop through the rows in the result set */
        rc = SQLFetch(hStmt);
        (*answerInfo).push_back("|[");
        while (SQL_SUCCEEDED(rc)) {

            // заносим в ответ начало сообщения отправки
            (*answerInfo).push_back("{\r\n");

            for (currentField = 1; currentField <= fieldCount; currentField++) {
                SQLDescribeCol(hStmt, currentField,
                    colName, sizeof(colName), 0, 0, 0, 0, 0);

                // начинаем составлять строку 
                help << "\t\"" << colName << "\": ";

                rc = SQLGetData(hStmt, currentField, SQL_C_CHAR, buf, sizeof(buf), (SQLLEN*)&ret);
                if (SQL_SUCCEEDED(rc) == false) {
                    printf("%d: sqlgetdata failed\n", (int)currentField);
                    *errorCode = -1;
                    continue;
                }
                if (ret <= 0) {
                    printf("%d: (no data)\n", (int)currentField);
                    *errorCode = -1;
                    continue;
                }
                // проверяем является ли полученное значение
                // числом или нет, если число - то ковычки не ставим!
                helpAgain << buf;
                // заканчиваем составлять строку файла
                if (StringIsNumber(helpAgain.str())) {
                    if (currentField + 1 <= fieldCount) {
                        (*answerInfo).push_back(help.str() + helpAgain.str() + ",\r\n");
                    }
                    else {
                        (*answerInfo).push_back(help.str() + helpAgain.str() + "\r\n");
                    }
                }
                else {
                    if (currentField + 1 <= fieldCount) {
                        (*answerInfo).push_back(help.str() + "\"" + helpAgain.str() + "\",\r\n");
                    }
                    else {
                        (*answerInfo).push_back(help.str() + "\"" + helpAgain.str() + "\"\r\n");
                    }
                }
                // не забываем очистить "буфер"
                help.str(string());
                helpAgain.str(string());
            }
            rc = SQLFetch(hStmt);
            rowCount++;

            // заканчиваем составлять строку файла
            if (SQL_SUCCEEDED(rc)) {
                (*answerInfo).push_back("},\r\n");
            }
            else {
                (*answerInfo).push_back("}]");
            }
        };
    }
}

BOOL WorkWithDatabase::MakeAndSendQuery(string query)
{
    // получили сам запрос в нужном формате и новом месте памяти
    CHAR* queryFinal = { strcpy(new char[query.length() + 1], query.c_str()) };

    /* Prepare SQL query */
    rc = SQLPrepare(hStmt, (SQLCHAR*)queryFinal, SQL_NTS);
    /* Excecute the query */
    rc = SQLExecute(hStmt);

    // если чтото пошло не так, то выводим ошибку и идем дальше
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    // а если все отлично, то пытаемся заполнить результат запроса в виде джейсон файла (если он будет)
    else {     
        RememberTableAnswer();
    }
    // если дошли до сюда, то все прошло успешно 
    return rc;
}

BOOL WorkWithDatabase::CallStoredProcedure(int storedProcedureCode)
{
    // смотрим какую именно процедуру нужно выполнить
    switch (storedProcedureCode) {
        // выполнение хранимой процедуры [dbo].[Get_ListOfEmployees] с нулем параметров
    case 0: {
        // пытаемся запустить эту процедуру
        rc = Get_ListOfEmployeesProcedure();
        break;
    }
        // выполнение хранимой процедуры [dbo].[Get_ListOfProducts] с нулем параметров
    case 1: {
        // пытаемся запустить эту процедуру
        rc = Get_ListOfProductsProcedure();
        break;
    }
        // выполнение хранимой процедуры [dbo].[Get_ListOfOrg] с нулем параметров
    case 2: {
        // пытаемся запустить эту процедуру
        rc = Get_ListOfOrgProcedure();
        break;
    }
        // выполнение хранимой процедуры [dbo].[Get_Report] с нулем параметров
    case 3: {
        // пытаемся запустить эту процедуру
        rc = Get_ReportProcedure();
        break;
    }
        // выполнение хранимой процедуры [dbo].[Get_InfoReport] с 1 одним входящим параметром 
    case 4: {
        // создаем переменную для приема входного параметра
        SQLINTEGER* dealId = new SQLINTEGER;
        // задаем в свежесозданную переменную значение входного параметра
        *dealId = stoi(incomingLineParameters[1]);
        // создаем и запускаем эту процедуру
        rc = Get_InfoReportProcedure(dealId);
        break;
    }
        // выполнение хранимой процедуры [dbo].[ADD_org] с 3-мя входящими параметрами 
    case 5: {
        // создаем переменные для приема входных параметров на основе этих данных
        string* orgName = new string(incomingLineParameters[1]);
        string* orgAddress = new string(incomingLineParameters[2]);
        string* orgPhone = new string(incomingLineParameters[3]);
        // создаем и запускаем эту процедуру
        rc = ADD_orgProcedure(orgName, orgAddress, orgPhone);
        break;
    }
        // выполнение хранимой процедуры [dbo].[EDIT_org] с 4-мя входящими параметрами 
    case 6: {
        // создаем переменные для приема входных параметров на основе этих данных
        int* orgId = new int(stoi(incomingLineParameters[1]));
        string* orgName = new string(incomingLineParameters[2]);
        string* orgAddress = new string(incomingLineParameters[3]);
        string* orgPhone = new string(incomingLineParameters[4]);
        // создаем и запускаем эту процедуру
        rc = EDIT_orgProcedure(orgId, orgName, orgAddress, orgPhone);
        break;
    }
        // выполнение хранимой процедуры [dbo].[DELETE_org] с 1-им входящим параметром 
    case 7: {
        // создаем переменные для приема входных параметров на основе этих данных
        int* orgId = new int(stoi(incomingLineParameters[1]));
        // создаем и запускаем эту процедуру
        rc = DELETE_orgProcedure(orgId);
        break;
    }
        // выполнение хранимой процедуры [dbo].[Fill_DealHat] с 4-мя входящими
        // параметрами и 1-им выходящим 
    case 8: {
        // создаем переменные для приема входных параметров на основе этих данных запроса
        string* dealDate = new string(incomingLineParameters[1]);
        string* dealType = new string(incomingLineParameters[2]);
        int* clientId = new int(stoi(incomingLineParameters[3]));
        int* employeeId = new int(stoi(incomingLineParameters[4]));
        // пытаемся запустить эту процедуру
        rc = Fill_DealHatProcedure(dealDate, dealType, clientId, employeeId, outputIntParameter);
        break;
    }
        // выполнение хранимой процедуры [dbo].[Fill_Deal] с 5-мя входящими параметрами
    case 9: {
        // создаем переменные для приема входных параметров на основе этих данных запроса
        int* countProducts = new int(stoi(incomingLineParameters[1]));
        int* price = new int(stoi(incomingLineParameters[2]));
        int* productID = new int(stoi(incomingLineParameters[3]));
        int* dealHatID = new int(stoi(incomingLineParameters[4]));
        int* unitOfMeasurementsID = new int(stoi(incomingLineParameters[5]));
        // пытаемся запустить эту процедуру
        rc = Fill_DealProcedure(countProducts, price, productID,
                                dealHatID, unitOfMeasurementsID);
        break;
    }
        // выполнение хранимой процедуры [dbo].[Get_UnitOfMeasurements] с нулем параметров
    case 10: {
        // пытаемся запустить эту процедуру
        rc = Get_UnitOfMeasurementsProcedure();
        break;
    }
        // выполнение хранимой процедуры [dbo].[Get_Product] с нулем параметров
    case 11: {
        // пытаемся запустить эту процедуру
        rc = Get_ProductProcedure();
        break;
    }
        // выполнение хранимой процедуры [dbo].[EDIT_countProducts] с 2-мя входящими параметрами
    case 12: {
        // создаем переменные для приема входных параметров на основе этих данных запроса
        int* productID = new int(stoi(incomingLineParameters[1]));
        int* countProducts = new int(stoi(incomingLineParameters[2]));
        // пытаемся запустить эту процедуру
        rc = EDIT_countProductsProcedure(productID, countProducts);
        break;
    }
    default:
        break;
    }

    // если чтото пошло не так, то выводим ошибку и идем дальше
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    // а если все отлично, то пытаемся заполнить результат запроса в виде джейсон файла (если он будет)
    else {
        RememberTableAnswer();
    }

    // если дошли до сюда, то все прошло успешно 
    return rc;
}

vector<string>* WorkWithDatabase::MakeRequest(string incomingLine)
{
    // выделяем память и подключаемся к БД
    AllocateHandlers();
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }

    // сначала нужно распарсить строку на параметры
    bool parametersIsCorrect = GetParameters(incomingLine);
    // не забываем проинициализировать переменную статуса положительным результатом
    *errorCode = 1;
    // и поставить стартовое значение для универсального выходящего Int параметра
    *outputIntParameter = -1;

    // если параметры были получены корректно
    if (parametersIsCorrect) {
        // сначала рассматриваем отправки простого запроса с получением табличных данных 
        if (strcmp(incomingLineParameters[0].c_str(), "Query") == 0) 
            MakeAndSendQuery(incomingLineParameters[1]);

        /// если используем вызов хранимой РЕАЛЬНОЙ процедуры (сначала проверяем
        /// есть ли значение для данного ключа-запроса в словаре)
        else if (requestСodes.find(incomingLineParameters[0].c_str()) != requestСodes.end())
            CallStoredProcedure(requestСodes[incomingLineParameters[0]]);        

        // если неудачно отправили запрос  
        else 
            *errorCode = -1; 
    }
    else 
        *errorCode = -1;

    // если мы использовали процедуру с выходящим параметром, то ставим это значение в ответ
    if (*outputIntParameter != -1) 
        (*answerInfo).push_back("|" + std::to_string(*outputIntParameter));

    // в конец не забываем поставить статус ошибки, который потом показывается сверху
    (*answerInfo).push_back("STATUS:" + std::to_string(*errorCode) + "\r\n");
    // а в конце не забыть стереть параметры из вектора
    incomingLineParameters.clear();

    // высвобождаем память и отключаемся от БД
    FreeHandlers();
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }

    // и теперь можно смело отправлять ответ на сервер
    return answerInfo;    
}

void WorkWithDatabase::SetConnectionLine(string line)
{
    strcpy(connectionString, line.c_str());
}

WorkWithDatabase::WorkWithDatabase()
{
    /// далее задаем строку подключение к БД (если она есть) ПЕРЕД 
    /// тем как выделить память под ресурсы и перед самим
    /// собственно подключением к БД
    string databaseLine;
    string text;
    std::ifstream ReadIniFile("settings.ini.txt");
    while (getline(ReadIniFile, text)) {
        if (text.find("string") != string::npos) {
            size_t pos = text.find(':') + 1;
            databaseLine = text.substr(pos, text.length() - pos);
            cout << databaseLine << '\n';
            SetConnectionLine(databaseLine);
        }
    }
    ReadIniFile.close();    
    /// проициализируем ключи для словаря
    /// чтобы потом просто получать значению по ключу
    /// вместо громоздких конструкций else if
    requestСodes["Get_ListOfEmployees"] = 0;
    requestСodes["Get_ListOfProducts"] = 1;
    requestСodes["Get_ListOfOrg"] = 2;
    requestСodes["Get_Report"] = 3;
    requestСodes["Get_InfoReport"] = 4;
    requestСodes["ADD_org"] = 5;
    requestСodes["EDIT_org"] = 6;
    requestСodes["DELETE_org"] = 7;
    requestСodes["Fill_DealHat"] = 8;
    requestСodes["Fill_Deal"] = 9;
    requestСodes["Get_UnitOfMeasurements"] = 10;
    requestСodes["Get_Product"] = 11;
    requestСodes["EDIT_countProducts"] = 12;
}
WorkWithDatabase::~WorkWithDatabase()
{    
}





