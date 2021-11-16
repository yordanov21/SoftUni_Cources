#include <iostream>
#include <vector>
#include <string>
#include <sstream>  

using namespace std;

std::string replaceAll(std::string str, const std::string& from, const std::string& to) {
	size_t start_pos = 0;
	while ((start_pos = str.find(from, start_pos)) != std::string::npos) {
		str.replace(start_pos, from.length(), to);
		start_pos += to.length();
	}
	return str;
}

int main() {

	string line = "";
	getline(cin, line);

	string word1 = "";
	string word2 = "";

	getline(cin, word1);
	getline(cin, word2);

	string result = replaceAll(line, word1, word2);
	cout << result;

	return 0;
}