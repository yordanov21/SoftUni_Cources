#include<iostream>
#include<string>  // for getline();
#include<numeric>
#include<sstream>
#include <vector>
#include <list>

using namespace std;

int main() {

	string line = "";
	getline(cin, line);

	string firstCharacters = "";
	getline(cin, firstCharacters);

	string secondCharacters = "";
	getline(cin, secondCharacters);

	int furstNum = 0;

	int secondNum = 0;

	int power = 1;
	for (size_t i = 0; i < firstCharacters.size(); i++)
	{
		char currentChar = firstCharacters[i];
		int curentNUm = line.find(currentChar);

		furstNum += curentNUm;
		furstNum *= 10;
	}

	int power2 = 1;
	for (size_t i = 0; i < secondCharacters.size(); i++)
	{
		char currentChar2 = secondCharacters[i];
		int curentNUm2 = line.find(currentChar2);

		secondNum += curentNUm2;
		secondNum *= 10;
	}

	int sum = furstNum / 10 + secondNum / 10;
	string result = "";
	while (sum)
	{	
		int index = sum % 10;
		result.push_back( line[index]);
		sum /= 10;
	}
	int SIZE = result.size();
	for (int i = SIZE-1; i>=0;)
	{
		cout << result[i];
		i--;
	}

	return 0;
}