#include "WorkWithDatabase.h"

BOOL WorkWithDatabase::Get_ListOfEmployeesProcedure()
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [Get_ListOfEmployees]}", SQL_NTS);
    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}
BOOL WorkWithDatabase::Get_ListOfProductsProcedure()
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [Get_ListOfProducts]}", SQL_NTS);
    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}
BOOL WorkWithDatabase::Get_ListOfOrgProcedure()
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [Get_ListOfOrg]}", SQL_NTS);
    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}
BOOL WorkWithDatabase::Get_ReportProcedure()
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [Get_Report]}", SQL_NTS);
    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}
BOOL WorkWithDatabase::Get_InfoReportProcedure(SQLINTEGER* dealId)
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [Get_InfoReport](?)}", SQL_NTS);
    // ������ ���� �������� �������� (@dealId int)
    rc = SQLBindParameter(hStmt, 1, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)dealId, 0, NULL);

    // �������� ��������� ��� �����
    rc = SQLGetStmtAttrA(hStmt, SQL_ATTR_IMP_PARAM_DESC, &hIpd, 0, 0);
    // ��������� �������� �������� �������� (@dealId int)
    rc = SQLSetDescField(hIpd, 1, SQL_DESC_NAME, (SQLPOINTER)"@dealId", SQL_NTS);

    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}
BOOL WorkWithDatabase::ADD_orgProcedure(string* orgName, string* orgAddress, string* orgPhone)
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [ADD_org](?, ?, ?)}", SQL_NTS);
    // ������ �������� ��������� (@orgName nvarchar, @orgAddress nvarchar, @orgPhone nvarchar)
    rc = SQLBindParameter(hStmt, 1, SQL_PARAM_INPUT, SQL_C_CHAR, SQL_CHAR, orgName->size(), 0, (SQLPOINTER)orgName->c_str(), 0, NULL);
    rc = SQLBindParameter(hStmt, 2, SQL_PARAM_INPUT, SQL_C_CHAR, SQL_CHAR, orgAddress->size(), 0, (SQLPOINTER)orgAddress->c_str(), 0, NULL);
    rc = SQLBindParameter(hStmt, 3, SQL_PARAM_INPUT, SQL_C_CHAR, SQL_CHAR, orgPhone->size(), 0, (SQLPOINTER)orgPhone->c_str(), 0, NULL);

    // �������� ��������� ��� �����
    rc = SQLGetStmtAttrA(hStmt, SQL_ATTR_IMP_PARAM_DESC, &hIpd, 0, 0);

    // ��������� �������� ��������� � ���-�� ������������������ 
    rc = SQLSetDescField(hIpd, 1, SQL_DESC_NAME, (SQLPOINTER)"@orgName", SQL_NTS);
    rc = SQLSetDescField(hIpd, 2, SQL_DESC_NAME, (SQLPOINTER)"@orgAddress", SQL_NTS);
    rc = SQLSetDescField(hIpd, 3, SQL_DESC_NAME, (SQLPOINTER)"@orgPhone", SQL_NTS);

    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}
BOOL WorkWithDatabase::EDIT_orgProcedure(int* orgId, string* orgName,
    string* orgAddress, string* orgPhone)
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [EDIT_org](?, ?, ?, ?)}", SQL_NTS);
    // ������ �������� ��������� (@orgId int, @orgName nvarchar, @orgAddress nvarchar, @orgPhone nvarchar)
    rc = SQLBindParameter(hStmt, 1, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)orgId, 0, NULL);
    rc = SQLBindParameter(hStmt, 2, SQL_PARAM_INPUT, SQL_C_CHAR, SQL_CHAR, orgName->size(), 0, (SQLPOINTER)orgName->c_str(), 0, NULL);
    rc = SQLBindParameter(hStmt, 3, SQL_PARAM_INPUT, SQL_C_CHAR, SQL_CHAR, orgAddress->size(), 0, (SQLPOINTER)orgAddress->c_str(), 0, NULL);
    rc = SQLBindParameter(hStmt, 4, SQL_PARAM_INPUT, SQL_C_CHAR, SQL_CHAR, orgPhone->size(), 0, (SQLPOINTER)orgPhone->c_str(), 0, NULL);

    // �������� ��������� ��� �����
    rc = SQLGetStmtAttrA(hStmt, SQL_ATTR_IMP_PARAM_DESC, &hIpd, 0, 0);

    // ��������� �������� ��������� � ���-�� ������������������ 
    rc = SQLSetDescField(hIpd, 1, SQL_DESC_NAME, (SQLPOINTER)"@orgId", SQL_NTS);
    rc = SQLSetDescField(hIpd, 2, SQL_DESC_NAME, (SQLPOINTER)"@orgName", SQL_NTS);
    rc = SQLSetDescField(hIpd, 3, SQL_DESC_NAME, (SQLPOINTER)"@orgAddress", SQL_NTS);
    rc = SQLSetDescField(hIpd, 4, SQL_DESC_NAME, (SQLPOINTER)"@orgPhone", SQL_NTS);

    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}
BOOL WorkWithDatabase::DELETE_orgProcedure(int* orgId)
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [DELETE_org](?)}", SQL_NTS);
    // ������ �������� ��������� (@orgId int)
    rc = SQLBindParameter(hStmt, 1, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)orgId, 0, NULL);

    // �������� ��������� ��� �����
    rc = SQLGetStmtAttrA(hStmt, SQL_ATTR_IMP_PARAM_DESC, &hIpd, 0, 0);
    // ��������� �������� ��������� � ���-�� ������������������ 
    rc = SQLSetDescField(hIpd, 1, SQL_DESC_NAME, (SQLPOINTER)"@orgId", SQL_NTS);

    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}
BOOL WorkWithDatabase::Fill_DealHatProcedure(string* dealDate, string* dealType,
    int* clientId, int* employeeId, int* dealHatId)
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [Fill_DealHat](?, ?, ?, ?, ?)}", SQL_NTS);
    // ������ �������� ��������� (@dealDate, @dealType, @clientId, @employeeId)
    rc = SQLBindParameter(hStmt, 1, SQL_PARAM_INPUT, SQL_C_CHAR, SQL_TIMESTAMP, 0, 0, (SQLPOINTER)dealDate->c_str(), 0, NULL);
    rc = SQLBindParameter(hStmt, 2, SQL_PARAM_INPUT, SQL_C_CHAR, SQL_CHAR, dealType->size(), 0, (SQLPOINTER)dealType->c_str(), 0, NULL);
    rc = SQLBindParameter(hStmt, 3, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)clientId, 0, NULL);
    rc = SQLBindParameter(hStmt, 4, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)employeeId, 0, NULL);
    // � ������ ������� ������ �������� (@dealHatId)
    rc = SQLBindParameter(hStmt, 5, SQL_PARAM_INPUT_OUTPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)dealHatId, 0, NULL);

    // �������� ������ � ��������
    rc = SQLGetStmtAttrA(hStmt, SQL_ATTR_IMP_PARAM_DESC, &hIpd, 0, 0);
    // ��������� ��� �������� ����� ���������
    rc = SQLSetDescField(hIpd, 1, SQL_DESC_NAME, (SQLPOINTER)"@dealDate", SQL_NTS);
    rc = SQLSetDescField(hIpd, 2, SQL_DESC_NAME, (SQLPOINTER)"@dealType", SQL_NTS);
    rc = SQLSetDescField(hIpd, 3, SQL_DESC_NAME, (SQLPOINTER)"@clientId", SQL_NTS);
    rc = SQLSetDescField(hIpd, 4, SQL_DESC_NAME, (SQLPOINTER)"@employeeId", SQL_NTS);
    rc = SQLSetDescField(hIpd, 5, SQL_DESC_NAME, (SQLPOINTER)"@dealHatId", SQL_NTS);

    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
    }
    return rc;
}
BOOL WorkWithDatabase::Fill_DealProcedure(int* countProducts, int* price, int* productID,
    int* dealHatID, int* unitOfMeasurementsID)
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [Fill_Deal](?, ?, ?, ?, ?)}", SQL_NTS);
    // ������ �������� ��������� (@countProducts, @price, @productID, @dealHatID, @unitOfMeasurementsID)
    rc = SQLBindParameter(hStmt, 1, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)countProducts, 0, NULL);
    rc = SQLBindParameter(hStmt, 2, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)price, 0, NULL);
    rc = SQLBindParameter(hStmt, 3, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)productID, 0, NULL);
    rc = SQLBindParameter(hStmt, 4, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)dealHatID, 0, NULL);
    rc = SQLBindParameter(hStmt, 5, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)unitOfMeasurementsID, 0, NULL);

    // �������� ������ � ��������
    rc = SQLGetStmtAttrA(hStmt, SQL_ATTR_IMP_PARAM_DESC, &hIpd, 0, 0);
    // ��������� ��� �������� ����� ���������
    rc = SQLSetDescField(hIpd, 1, SQL_DESC_NAME, (SQLPOINTER)"@countProducts", SQL_NTS);
    rc = SQLSetDescField(hIpd, 2, SQL_DESC_NAME, (SQLPOINTER)"@price", SQL_NTS);
    rc = SQLSetDescField(hIpd, 3, SQL_DESC_NAME, (SQLPOINTER)"@productID", SQL_NTS);
    rc = SQLSetDescField(hIpd, 4, SQL_DESC_NAME, (SQLPOINTER)"@dealHatID", SQL_NTS);
    rc = SQLSetDescField(hIpd, 5, SQL_DESC_NAME, (SQLPOINTER)"@unitOfMeasurementsID", SQL_NTS);

    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
    }
    return rc;
}
BOOL WorkWithDatabase::Get_UnitOfMeasurementsProcedure()
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [Get_UnitOfMeasurements]}", SQL_NTS);
    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}
BOOL WorkWithDatabase::Get_ProductProcedure()
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [Get_Product]}", SQL_NTS);
    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}
BOOL WorkWithDatabase::EDIT_countProductsProcedure(int* productID,
    int* countProducts)
{
    // �������������� �������� � ����������
    rc = SQLPrepareA(hStmt, (SQLCHAR*)"{call [EDIT_countProducts](?, ?)}", SQL_NTS);
    // ������ ���� �������� �������� (@productID int)
    rc = SQLBindParameter(hStmt, 1, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)productID, 0, NULL);
    // ������ ������ �������� �������� (@countProducts int)
    rc = SQLBindParameter(hStmt, 2, SQL_PARAM_INPUT, SQL_C_SLONG, SQL_INTEGER, 0, 0, (SQLPOINTER)countProducts, 0, NULL);

    // �������� ��������� ��� �����
    rc = SQLGetStmtAttrA(hStmt, SQL_ATTR_IMP_PARAM_DESC, &hIpd, 0, 0);
    // ��������� �������� �������� �������� (@productID int)
    rc = SQLSetDescField(hIpd, 1, SQL_DESC_NAME, (SQLPOINTER)"@productID", SQL_NTS);
    // ��������� �������� �������� �������� (@countProducts int)
    rc = SQLSetDescField(hIpd, 2, SQL_DESC_NAME, (SQLPOINTER)"@countProducts", SQL_NTS);

    // �������� ��������� ���������
    rc = SQLExecute(hStmt);
    // �������, ���� �� ������ 
    if (!SQL_SUCCEEDED(rc)) {
        DisplayError(SQL_HANDLE_STMT, hStmt);
        *errorCode = -1;
    }
    return rc;
}