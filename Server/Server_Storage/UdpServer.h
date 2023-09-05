#pragma once

#include <boost/asio.hpp>
#include <boost/array.hpp>
#include <boost/bind/bind.hpp>
#include <boost/shared_ptr.hpp>

#include <ctime>
#include <map>
#include <fstream>

#include "WorkWithDatabase.h"

using namespace std; // For time_t, time and ctime;
using boost::asio::ip::udp;
using std::map;

class UdpServer
{
private:
	// обьект самого сокета
	udp::socket socket_;
	// обьект используемой в данный момент удаленной точки 
	udp::endpoint remoteEndpoint_;
	// буффер для приема данных
	boost::array<char, 256> recieverBuffer_;
	// для более простой работы с сообщениями	
	stringstream strStream;

	// указатель на вектор для приема ответа от БД, тоже в виде вектора 
	vector<string>* answerFromBD;

	// обьект для взаимодействия с БД
	WorkWithDatabase* WWDb = new WorkWithDatabase;

	/// <summary>
	/// Преобразование буфера в корректную строку
	/// </summary>
	/// <param name="buffer">сам буфер</param>
	/// <param name="buffer_size">размер буфера</param>
	/// <returns>корректная строка</returns>
	string StrFromBuffer(boost::array<char, 256> buffer,
						 size_t buffer_size);

	/// <summary>
	/// Метод старта приема сообщений от пользователей
	/// </summary>
	void StartReceive();

	/// <summary>
	/// Управление после принятия запроса-сообщения
	/// </summary>
	/// <param name="error">объект класса ошибок</param>
	/// <param name="buffer_size">размер полученного сообщения</param>
	void HandleReceive(const boost::system::error_code& error,
					   size_t buffer_size);

	/// <summary>
	/// Управление после отправки сообщения 
	/// </summary>
	/// <param name="endpoint">конечная точка отправления сообщения</param>
	/// <param name="answer">строка с ответом от сервера</param>
	/// <param name="err">обьект ошибки</param>
	/// <param name="buffer_size">размер ответа от сервера</param>
	void HandleSend(udp::endpoint endpoint,
					boost::shared_ptr<string> answer,
					const boost::system::error_code& err,
					std::size_t buffer_size);

	/// <summary>
	/// Отправить сообщение на определенную удаленную точку целиком в виде строки
	/// </summary>
	/// <param name="endpoint">определенная удаленная точка</param>
	/// <param name="answer">ответ от сервера в виде вектора строчек</param>
	void СomposeMessageAndSendToInFull(udp::endpoint endpoint, vector<string> answer);

	/// <summary>
	/// Отправить сообщение на определенную удаленную точку частями - построчно
	/// </summary>
	/// <param name="endpoint">определенная удаленная точка</param>
	/// <param name="answer">ответ от сервера в виде вектора строчек</param>
	void СomposeMessageAndSendToInParts(udp::endpoint endpoint, vector<string> answer);

	/// <summary>
	/// Метод для написании истории сообщений в консоль, скорее для отладки
	/// и сохранения истории в отдельном классе
	/// </summary>
	/// <param name="endpoint">конечной точка для адреса</param>
	/// <param name="buffer_size">размер буффера</param>
	/// <param name="answer">строка с ответом</param>
	void PrintInfo(udp::endpoint endpoint,
				   std::size_t buffer_size,
				   boost::shared_ptr<string> answer);

public:
	/// <summary>
	/// конструктор с инициализацией через главный функциональный обьект 
	/// класса библиотеки boost
	/// </summary>
	/// <param name="io_context">главный функциональный обьект библиотеки boost</param>
    /// <param name="adress">адресс в виде строки для инциализации сокета</param>
	/// <param name="port">порт для прослушки</param>
	UdpServer(boost::asio::io_context& io_context,
			  string adress,
			  int port);
};

