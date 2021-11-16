#include <iostream>
#include <vector>
using namespace std;


int main()
{
	const int arrMAXLength = 100;

	int arrLength = 1;
	cin >> arrLength;
	int arrayOfNumbers[arrMAXLength] = {};

	for (int i = 0; i < arrLength; i++)
	{
		cin >> arrayOfNumbers[i];
	}

	int searchedNum;
	int indexNUm=-1;
	cin >> searchedNum;

	for (int i = 0; i < arrLength; i++)
	{
		if (searchedNum == arrayOfNumbers[i])
		{
			indexNUm = i;
		}
	}

	cout << indexNUm; 
}
