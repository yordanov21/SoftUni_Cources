// 01_Operations.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;

vector<int> readInput()
{
	vector<int> vec(2);

	cin >> vec[0] >> vec[1];

	return vec;
}

int main()
{
	const vector<int> vec = readInput();
	double result;
	while (true)
	{
		char operation = '_';
		cin >> operation;

		if (operation == '+')
		{
			result = (double)(vec[0] + vec[1]);
			cout << result;
			return 0;
		}
		else if (operation == '-')
		{
			result = (double)(vec[0] - vec[1]);
			cout << result;
			return 0;
		}
		else if (operation == '*')
		{
			result = (double)(vec[0] * vec[1]);
			cout << result;
			return 0;
		}
		else if (operation == '/')
		{
			result = (double)(vec[0] / vec[1]);
			cout << result;
			return 0;
		}
		else
		{
			cout << "try again\n";
		}

	}

	return 0;
}
	// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
	// Debug program: F5 or Debug > Start Debugging menu

	// Tips for Getting Started: 
	//   1. Use the Solution Explorer window to add/manage files
	//   2. Use the Team Explorer window to connect to source control
	//   3. Use the Output window to see build output and other messages
	//   4. Use the Error List window to view errors
	//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
	//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
