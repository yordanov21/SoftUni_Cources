#include<iostream>
#include <cmath>
#include <vector>
#include <algorithm>    // std::sort, max_elemnt, min_element
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

	vector<int> frequentArr = {0,0,0,0,0,0,0,0,0,0};
	


	for (int i = 0; i < arrLength; i++)
	{
		switch (arrayOfNumbers[i]) {
		case 0:
			frequentArr[0]++;
			break;
		case 1:
			frequentArr[1]++;
			break;
		case 2:
			frequentArr[2]++;
			break;
		case 3:
			frequentArr[3]++;
			break;
		case 4:
			frequentArr[4]++;
			break;
		case 5:
			frequentArr[5]++;
			break;
		case 6:
			frequentArr[6]++;
			break;
		case 7:
			frequentArr[7]++;
			break;
		case 8:
			frequentArr[8]++;
			break;
		case 9:
			frequentArr[9]++;
			break;
		default:
			// code block
			break;
		}
	}

	int maxNum= *max_element(frequentArr.begin(), frequentArr.end());

	for (int i = 0; i <= 9; i++)
	{
		if(frequentArr[i]==maxNum)
		cout << i << ' ';
	}
	
	return 0;
}
