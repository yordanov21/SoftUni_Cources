#include<iostream>
#include <cmath>
#include <vector>
using namespace std;

int main() {
	const int arrMAXLength = 100;

	int arrLength = 1;
	cin >> arrLength;
	int arrayOfNumbers[arrMAXLength] = {};

	for (int i = 0; i < arrLength; i++)
	{
		cin >> arrayOfNumbers[i];
	}

	int arrSum = 0;

	for (int i = 0; i < arrLength; i++)
	{
		arrSum += arrayOfNumbers[i];
	}

	double average =arrSum / arrLength;

	for (int i = 0; i < arrLength; i++)
	{
		if (average <= arrayOfNumbers[i]) 
		{
			cout << arrayOfNumbers[i] << ' ';
		}
	}

	return 0;
}

