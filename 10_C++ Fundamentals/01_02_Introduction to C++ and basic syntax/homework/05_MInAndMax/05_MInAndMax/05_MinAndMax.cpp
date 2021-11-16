#include<iostream>
#include <cmath>
using namespace std;

int main() {
	int numbers;
	int minNumber= INT_MAX;
	int maxNumber = INT_MIN;

	cin >> numbers;

	for (int i = 1; i <= numbers; ++i)
	{
		int currentNum;
		cin >> currentNum;
		if (currentNum < minNumber) {
			minNumber = currentNum;
		}

		if(currentNum > maxNumber)
		{
			maxNumber = currentNum;
		}
	}

	cout << minNumber << " "<<maxNumber;
	return 0;
}