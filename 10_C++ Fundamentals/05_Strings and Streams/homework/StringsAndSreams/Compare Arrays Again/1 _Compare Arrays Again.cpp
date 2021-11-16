#include<iostream>
#include <cmath>
#include <vector>
#include <string>
using namespace std;

int main() {

	string lineOne= "";
	string lineTwo= "";
	getline(cin, lineOne);
	getline(cin, lineTwo);


	if (lineOne == lineTwo)
	{
		cout << "equal";
	}
	else
	{
		cout << "not equal";
	}

	return 0;
}