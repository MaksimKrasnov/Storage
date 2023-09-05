#define _CRT_SECURE_NO_WARNINGS
#include "UdpServer.h"

/// <summary>
/// Просто вынесенная функция преобразования сейчашнего
/// времени в строку для логирования информации
/// <summary>
/// <returns>текущее время в виде строки</returns>
string make_daytime_string()
{
	time_t now = time(0);
	return ctime(&now);
}
/// <summary>
/// Простая вынесенная функция нахождения номера порта в строке 
/// </summary>
/// <param name="str">строка, в которой нужно искать</param>
/// <returns>номер порта, как число</returns>
int find_port_in_str(string str)
{
	size_t pos = str.find(':', 0);
	string portStr = str.substr(pos + 1, str.length() - pos - 1);
	return stoi(portStr);
}
/// <summary>
/// Вспомогательная простая функция для нахождения адреса в строке
/// </summary>
/// <param name="str">присланная строка с адресом</param>
/// <returns>полученный адрес из строки</returns>
boost::asio::ip::address_v4 find_adress_in_str(string str)
{
	boost::asio::ip::address_v4 addr(
		boost::asio::ip::address_v4::
		from_string(str.substr(0, str.find(':'))));
	return addr;
}



string UdpServer::StrFromBuffer(boost::array<char, 256> buffer,
								size_t buffer_size)
{
	string rezult = buffer.data();
	rezult = rezult.substr(0, buffer_size);
	return rezult;
}

void UdpServer::StartReceive()
{
	/// Функция ip::udp::socket::async_receive_from() заставляет приложение
	/// прослушивать в фоновом режиме новый запрос. Когда такой запрос получен,
	/// объект io_context вызовет функцию handle_receive() с двумя аргументами:
	/// значением типа boost::system::error_code, указывающим, была ли операция
	/// успешной или неудачной, и значением size_t bytes_transferred,
	/// указывающим количество полученных байтов.
	socket_.async_receive_from(
		boost::asio::buffer(recieverBuffer_),
		remoteEndpoint_,
		boost::bind(&UdpServer::HandleReceive, this,
			boost::asio::placeholders::error,
			boost::asio::placeholders::bytes_transferred));
}

void UdpServer::HandleReceive(const boost::system::error_code& error,
							  size_t buffer_size)
{
	if (!error) {
		// сначала просто расшифровываем ответ 
		string message = StrFromBuffer(recieverBuffer_, buffer_size);	

		// отправляем запрос к БД на основе этого ответа и получаем ответ
		answerFromBD = WWDb->MakeRequest(message);
		// отправляем сообщение конкретному юзеру строку целиком
		СomposeMessageAndSendToInFull(remoteEndpoint_, *answerFromBD);

		// пишем информацию в лог
		PrintInfo(remoteEndpoint_, buffer_size, nullptr);	

		// чистим вектор 
		(*answerFromBD).clear();
	}
	// после взаимодействия, принимаем сообщения еще
	StartReceive();
}

void UdpServer::HandleSend(udp::endpoint endpoint,
						   boost::shared_ptr<std::string> answer,
						   const boost::system::error_code& error,
						   std::size_t buffer_size)
{
	if (!error) {
		// просто запоминаем инфу 
		PrintInfo(endpoint, buffer_size, answer);
	}	
}

void UdpServer::СomposeMessageAndSendToInFull(udp::endpoint endpoint,
											  vector<string> answer)
{
	// пишем последний элемент ответа (статус об ошибке)
	strStream << answer[answer.size() - 1];
	// после того как записали, можно его убрать из вектора
	answer.pop_back();
	// а теперь каждую строку пишем в поток ответа 
	for (string answerLine : answer) {
		strStream << answerLine;
	}

	// создаем отправляемую переменную с готовым ответом
	boost::shared_ptr<string> answerFinal(new string(strStream.str().c_str()));
	// наконец шлем ответ 
	socket_.async_send_to(boost::asio::buffer(*answerFinal), endpoint,
		boost::bind(&UdpServer::HandleSend, this, endpoint, answerFinal,
			boost::asio::placeholders::error,
			boost::asio::placeholders::bytes_transferred));

	// не забываем почистить "буфер"
	strStream.str(string());
}

void UdpServer::СomposeMessageAndSendToInParts(udp::endpoint endpoint,
											   vector<string> answer)
{
	// создаем отправляемую переменную с готовым ответом со статусом ошибки
	boost::shared_ptr<string> answerStatus(new string(answer[answer.size() - 1]));
	// наконец шлем ответ 
	socket_.async_send_to(boost::asio::buffer(*answerStatus), endpoint,
		boost::bind(&UdpServer::HandleSend, this, endpoint, answerStatus,
			boost::asio::placeholders::error,
			boost::asio::placeholders::bytes_transferred));
	// после того как записали, можно его убрать из вектора
	answer.pop_back();
	
	// а теперь каждую строку ответа БД задаем в виде переменных спец. и отправляем
	for (string lineStr : answer) {
		// создаем отправляемую переменную с готовым ответом
		boost::shared_ptr<string> answerLine(new string(lineStr));
		// наконец шлем ответ 
		socket_.async_send_to(boost::asio::buffer(*answerLine), endpoint,
			boost::bind(&UdpServer::HandleSend, this, endpoint, answerLine,
				boost::asio::placeholders::error,
				boost::asio::placeholders::bytes_transferred));
	}
}

void UdpServer::PrintInfo(udp::endpoint endpoint,
								 std::size_t buffer_size,
								 boost::shared_ptr<string> answer)
{
	// если это мы получили сообщение от клиента
	if (answer == nullptr) {
		// пишем отладочную информацию в стрингБилдер  
		strStream << endpoint <<
			"]: user message -> " <<
			StrFromBuffer(recieverBuffer_, buffer_size) <<
			" [local time:" <<
			make_daytime_string().substr(0, make_daytime_string().length() - 1) << ']';
		// выводим эту информацию в консоль
		cout << strStream.str() << '\n';
		// а вот так вот очищаем использованный поток
		strStream.str(std::string());
	}
	// если отправляли сообщение юзеру
	else {
		// пишем отладочную информацию в стрингБилдер  
		strStream << endpoint <<
			"]: server answer <- " <<
			*answer << " [local time:" <<
			make_daytime_string().substr(0, make_daytime_string().length() - 1) << ']';
		// выводим эту информацию в консоль
		cout << strStream.str() << '\n';
		// и вот так вот очищаем поток
		strStream.str(std::string());
	}
}

UdpServer::UdpServer(boost::asio::io_context& io_context, string adress, int port)
	: socket_(io_context, udp::endpoint{ 
	boost::asio::ip::address_v4::from_string(adress), boost::asio::ip::port_type(port)})
{
	// после инициализации сокета сразу начинаем "слушать" сообщений
	StartReceive();
}
