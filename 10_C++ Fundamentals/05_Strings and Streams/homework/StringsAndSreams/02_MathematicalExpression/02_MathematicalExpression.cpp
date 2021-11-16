#include<iostream>
#include <cmath>
#include <vector>
#include <string>
using namespace std;

int main() {

	string line = "";
	getline(cin, line);

	int leftBrecket = 0;
	int rightBrecket = 0;
	for (size_t i = 0; i < line.size(); i++)
	{
		if (line[i] == '(')
		{
			leftBrecket++;
		}
		if (line[i] == ')')
		{
			rightBrecket++;
		}
	}
	if (leftBrecket == rightBrecket)
	{
		cout << "correct";
	}
	else
	{
		cout << "incorrect";
	}

	return 0;
}