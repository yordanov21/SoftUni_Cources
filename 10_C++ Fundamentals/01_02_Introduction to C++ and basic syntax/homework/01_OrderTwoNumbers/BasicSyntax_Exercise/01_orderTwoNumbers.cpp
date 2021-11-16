#include<iostream>
using namespace std;

int main() {
	int numberOne;
	int numberTwo;

	cin >> numberOne >> numberTwo;

	if (numberOne > numberTwo)
	{
		cout << numberTwo << ' ' << numberOne<< endl;
	}
	else
	{
		cout << numberOne << ' ' << numberTwo<< endl;
	}

	return 0;
}

