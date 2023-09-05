
#include <tchar.h>

#include "UdpServer.h"

int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "Russian");

	// две переменные для инициализации эндпоинта
	string serverIp;
	string serverPort;
	/// далее идет участок для нахождения нужных данных 
	/// (айпи адреса сервера и его порта)
	/// из файла инициализации
	string text;
	ifstream ReadIniFile("settings.ini.txt");
	while (getline(ReadIniFile, text)) {
		if (text.find("ip") != string::npos) {
			size_t pos = text.find(':') + 1;
			serverIp = text.substr(pos, text.length() - pos);
		}
		else if (text.find("port") != string::npos) {
			size_t pos = text.find(':') + 1;
			serverPort = text.substr(pos, text.length() - pos);
		}
	}
	// их вывод и закрытие файла
	cout << serverIp << ':';
	cout << serverPort << '\n';	
	ReadIniFile.close();
	// запуск сервера на основе этих данных 
	try {
		boost::asio::io_context io_context;
		UdpServer server(io_context, serverIp, stoi(serverPort));
		std::cout << "Server started\n";
		io_context.run();
	}
	catch (const std::exception& e) {
		std::cerr << e.what() << std::endl;
	}
    return 0;
}

