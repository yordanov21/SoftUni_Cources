#include<iostream>
#include <cmath>
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

	int count = 1;
	int currentCount = 1;
	int sequenseNum = arrayOfNumbers[arrLength-1];

	for (int i = 0; i < arrLength-1; i++)
	{
		int currentNum = arrayOfNumbers[i];
		int nextNum = arrayOfNumbers[i+1];
		if (nextNum == currentNum) {
			currentCount++;
			if (currentCount >= count) {
				count = currentCount;
				sequenseNum = currentNum;
			}
		} 
		else
		{
			currentCount = 1;
		}


	}

	for (int i = 0; i < count; i++)
	{
		cout << sequenseNum << ' ';
	}

	return 0;
}

