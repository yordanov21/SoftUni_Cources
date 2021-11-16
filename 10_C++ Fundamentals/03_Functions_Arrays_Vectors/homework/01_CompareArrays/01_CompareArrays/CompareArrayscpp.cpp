#include<iostream>
#include <cmath>
using namespace std;

bool areEqual(int arr1[], int length1, int arr2[], int length2);

int main() {
    const int arrMAXLength=100;

	int arrOneLength=1;
	cin >> arrOneLength;
	int arrOne[arrMAXLength] = {};

	for (int i = 0; i < arrOneLength; i++)
	{
		cin >> arrOne[i];
	}

	int arrTwoLength = 1;
	cin >> arrTwoLength;
	int arrTwo[arrMAXLength] = {};

	for (int i = 0; i < arrOneLength; i++)
	{
		cin >> arrTwo[i];
	}

	if (areEqual(arrOne, arrOneLength, arrTwo, arrTwoLength)) 
	{
		cout << "equal";
	}
	else
	{
		cout << "not equal";
	}
	


	return 0;
}

bool areEqual(int arr1[], int length1, int arr2[], int length2)
{
	if (length1 != length2) {
		return false;
	}

	for (int i = 0; i < length1; i++)
	{
		if (arr1[i] != arr2[i])
		{
			return false;
		}

	}

	return true;
}
