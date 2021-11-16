#include <iostream>
#include <vector>
using namespace std;


int main()
{

	string symbols;
	cin >> symbols;

	vector<int> vec;
	int sizeOfSymbols = symbols.size();
	for (int i = 0; i < sizeOfSymbols; ++i)
	{
		if( isdigit(symbols[i]))
		{
			int number = (int)symbols[i]-48;
			vec.push_back(number);
		}

	}

	int resultNumber = 0;
	int sizeOfVec = vec.size();
	for (int i = 0; i <sizeOfVec; ++i)
	{
		if (i == sizeOfVec - 1) 
		{
			resultNumber += vec[i];
		}
		else
		{
			resultNumber += vec[i] * pow(10 , (sizeOfVec - i - 1));
		}
		
	}

	double result = 1.0;
	result = sqrt(resultNumber*1.0);
	cout <<"Number is: " << resultNumber<<"\n";
	cout <<"Sqrt NUmber is: "<< result;
	return 0;

}