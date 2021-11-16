#include<iostream>
using namespace std;

int main() {
	int number1;
	int number2;
	int number3;

	cin >> number1 >> number2 >> number3;

	int sumOfNumbers = number1 * number2 * number3;

	if (sumOfNumbers >= 0)
	{
		cout << "+" << endl;
	}
	else
	{
		cout << "-" << endl;
	}

	return 0;
}