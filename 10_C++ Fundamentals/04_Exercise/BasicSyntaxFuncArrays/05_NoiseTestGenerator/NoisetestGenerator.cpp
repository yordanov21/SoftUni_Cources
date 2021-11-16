#include <iostream>
#include <vector>
#include <stdlib.h>
#include <time.h>

using namespace std;

const int MAX = 40;

// Returns a string of random alphabets of 
// length n. 
string randomString()
{
	string res = "";
	
	srand(time(0));
	
	for (int i = 0; i < 18; i++) {
		int randomNum= rand()%94+33;
		char symbol = randomNum ;
		res = res + symbol;
	}
	
	return res;
}

int main()
{

	string symbols = randomString();
	//cin >>rand(symbols);
	
	vector<int> vec;
	int sizeOfSymbols = symbols.size();
	for (int i = 0; i < sizeOfSymbols; ++i)
	{
		if (isdigit(symbols[i]))
		{
			int number = (int)symbols[i] - 48;
			vec.push_back(number);
		}

	}

	int resultNumber = 0;
	int sizeOfVec = vec.size();
	for (int i = 0; i < sizeOfVec; ++i)
	{
		if (i == sizeOfVec - 1)
		{
			resultNumber += vec[i];
		}
		else
		{
			resultNumber += vec[i] * pow(10, (sizeOfVec - i - 1));
		}

	}

	double result = 1.0;
	result = sqrt(resultNumber * 1.0);
	cout <<"Symbols are: " << symbols<< "\n";
	cout << "Number is: " << resultNumber << "\n";
	cout << "Sqrt NUmber is: " << result;
	return 0;

}