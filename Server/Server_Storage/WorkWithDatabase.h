#define _CRT_SECURE_NO_WARNINGS
#pragma once

#include <Windows.h>
#include <stdio.h>
#include <sqlext.h>
#include <time.h>

#include <sstream>
#include <iostream>
#include <fstream>
#include <vector>
#include <map>

using std::string;
using std::stringstream;
using std::vector;
using std::map;

using std::cout;
using std::endl;
using std::cin;
using std::stoi;

class WorkWithDatabase
{
private:

	map<string, int> requestСodes; // словарь для оптимизации по работе с запросами
	static const int charSize = 256; // размер для массивов ЧАР
	CHAR		  connectionString[charSize]; // статическая строка подключения к БД
	
	SQLCHAR       SqlState[6], Msg[SQL_MAX_MESSAGE_LENGTH]; // переменные для обработки ошибок
	SQLINTEGER    NativeError; // переменная для обработки ошибок
	SQLSMALLINT   i, MsgLen; // переменная для обработки ошибок
	SQLRETURN     returnCode; // переменная для обработки ошибок
	SQLLEN		  numRecs; // переменная для обработки ошибок	

	stringstream  help; // строковый поток для анализа строк на состояние - "число"
	stringstream  helpAgain; // еще один строковый поток для помощи если не хватило первого

	HENV		  hEnv = NULL; // хендлер окружения
	HDBC		  hDbc = NULL; // хендлер соединения
	HSTMT		  hStmt = NULL; // хендлер утверждения
	SQLHDESC      hIpd = NULL; // хендлер описания параметров
	
	CHAR		  szConnStrOut[charSize]; // аут строка для метода соединения
	int			  iConnStrLength2Ptr; // предпологаемая длина строки аут для метода соединения		

	SQLINTEGER	  rowCount = 0; // переменная для работы с таблицей - как ответа от БД после запроса 
	SQLSMALLINT   fieldCount = 0, currentField = 0; // переменные для работы с таблицей - как ответа от БД после запроса 
	SQLCHAR		  buf[charSize], colName[charSize]; // переменные для работы с таблицей - как ответа от БД после запроса 
	SQLINTEGER    ret; // переменная для работы с таблицей - как ответа от БД после запроса 
	
	RETCODE		  rc; /* ODBC API return status */

	SQLINTEGER*	  errorCode = new SQLINTEGER; // переменная для анализа об успешности операции 
	vector<string>* answerInfo = new vector<string>; // указатель на вектор с частями ответа от БД для клиента
	int*			outputIntParameter = new int; // переменная для запоминания выходных параметров  

	vector<string>  incomingLineParameters; // вектор с распличенной строкой пришедшей от клиента
	string		    delim = ";"; // знак разделитель в тексте приходящей строки 
	size_t		    prev = 0; // вспомогательная переменная для нахождения количества параметров
	size_t		    next; // вспомогательная переменная для нахождения количества параметров
	size_t		    delta = delim.length(); // вспомогательная переменная для нахождения количества параметров

private:
	// вспомогательный метод для разбиения входящей строки на параметры и знанесения их в вектор
	bool GetParameters(string incomingLine);
	// вспомогательный метод определения - является ли строка числом
	bool StringIsNumber(const string& s);
	// метод анализа и вывода ошибок
	void DisplayError(SQLSMALLINT t, SQLHSTMT h);
	// метод выделения памяти под хендлеры класса и последующего соединения с БД 
	BOOL AllocateHandlers();
	// метод освобождения памяти под хендлеры и отключения от БД
	BOOL FreeHandlers();


	// метод выполнения процедуры для получения списка всех сотрудников 
	// не имеет ни входных, ни выходных параметров
	BOOL Get_ListOfEmployeesProcedure();
	// метод выполнения процедуры для получения списка всех продуктов 
	// не имеет ни входных, ни выходных параметров
	BOOL Get_ListOfProductsProcedure();
	// метод выполнения процедуры для получения списка всех организаций! 
	// не имеет ни входных, ни выходных параметров
	BOOL Get_ListOfOrgProcedure();
	// метод выполнения процедуры получения Отчета 
	// не имеет ни входных, ни выходных параметров
	BOOL Get_ReportProcedure();
	// метод выполнения процедуры получения Отчета Конкретного 
	// имеет входные параметры: dealId; выходных параметров нет
	BOOL Get_InfoReportProcedure(SQLINTEGER* dealId);
	// метод выполнения процедуры ДОБАВЛЕНИЯ организации 
	// имеет входные параметры: @orgName, @orgAddress, @orgPhone; выходных параметров нет
	BOOL ADD_orgProcedure(string* orgName, string* orgAddress, string* orgPhone);
	// метод выполнения процедуры РЕДАКТИРОВАНИЯ организации 
	// имеет входные параметры: @orgName, @orgAddress, @orgPhone; выходных параметров нет
	BOOL EDIT_orgProcedure(int* orgId, string* orgName,
						   string* orgAddress, string* orgPhone);
	// метод выполнения процедуры УДАЛЕНИЯ организации 
	// имеет входной параметр @orgName; выходных параметров нет
	BOOL DELETE_orgProcedure(int* orgId);
	// метод выполнения процедуры ЗАПОЛНЕНИЯ ЗАГОЛОВКА СДЕЛКИ 
	// имеет входные параметры: @dealDate, @dealType, @clientId, @employeeId
	// и есть один аутпут параметр: @dealHatId
	BOOL Fill_DealHatProcedure(string* dealDate, string* dealType,
							   int* clientId, int* employeeId, int* dealHatId);
	// метод выполнения процедуры ЗАПОЛНЕНИЯ ТЕЛА СДЕЛКИ 
	// имеет входные параметры: @countProducts, @price,
	// @dealHatID, @employeeId, @unitOfMeasurementsID; выходных параметров - нет
	BOOL Fill_DealProcedure(int* countProducts, int* price, int* dealHatID,
							int* employeeId, int* unitOfMeasurementsID);
	// метод выполнения процедуры ПОЛУЧЕНИЯ СПИСКА ТИПОВ ЕДИНИЦ ИЗМЕРЕНИЯ
	// и их АЙДИШНИКОВ; нету ни входных, ни выходных параметров
	BOOL Get_UnitOfMeasurementsProcedure();
	// метод выполнения процедуры ПОЛУЧЕНИЯ СПИСКА ВСЕХ ПРОДУКТОВ
	// вместе С АЙДИШНИКАМИ; нету ни входных, ни выходных параметров
	BOOL Get_ProductProcedure();
	// метод выполнения процедуры ИЗМЕНЕНИЯ ОСТАТКА ТОВАРА НА СКЛАДЕ
	// имеет входные параметры: @productID, @countProducts
	BOOL EDIT_countProductsProcedure(int* productID, int* countProducts);

	// запоминаем какой-либо табличный ответ от БД
	void RememberTableAnswer();
	// в случае если пришел простой запрос на получение табличных данных
	BOOL MakeAndSendQuery(string query);
	// в случае когда надо вызывать хранимую процедуру из БД
	BOOL CallStoredProcedure(int storedProcedureCode);

public:
	// основной метод для работы с базой данных 
	vector<string>* MakeRequest(string incomingLine);

	// метод назначения строки соединения с БД вручную для инициализации
	void SetConnectionLine(string line);

	WorkWithDatabase();
	~WorkWithDatabase();
};

