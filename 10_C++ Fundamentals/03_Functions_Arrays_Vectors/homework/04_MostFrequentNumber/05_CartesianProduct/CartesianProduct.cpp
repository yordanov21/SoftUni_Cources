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

	int closestNum = INT_MAX;
	if (arrLength == 1) {
		 cout << 0;
	}
	else
	{
		for (int i = 0; i < arrLength; i++)
		{
			for (int j = 0; j < arrLength; j++)
			{
				int currentNum = abs(arrayOfNumbers[i] - arrayOfNumbers[j]);

				if (currentNum < closestNum && j != i) {
					closestNum = currentNum;
				}
			}
		}

		cout << closestNum;
	}
	
	return 0;
}
