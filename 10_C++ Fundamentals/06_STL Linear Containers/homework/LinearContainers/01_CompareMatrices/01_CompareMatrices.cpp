#include<iostream>
#include<string>  // for getline();
#include<numeric>
#include<sstream>
#include <vector>

using namespace std;

int main() {


	string matrixRows1AsString = "";
	getline(cin, matrixRows1AsString);
	int matrixRows1=stoi(matrixRows1AsString);

	vector<vector<int> > numMatrix1;

	for (int row = 0; row < matrixRows1; row++) {
		vector<int> inputRow;
		string rowLine = "";
		getline(cin, rowLine);
		istringstream lineStream(rowLine);

		string element;

		while (lineStream >> element)
		{		
			int num = stoi(element);
			inputRow.push_back(num);
		}

		numMatrix1.push_back(inputRow);
	}

	string matrixRows2AsString = "";
	getline(cin, matrixRows2AsString);
	int matrixRows2 = stoi(matrixRows2AsString);

	vector<vector<int> > numMatrix2;

	for (int row = 0; row < matrixRows2; row++) {
		vector<int> inputRow;
		string rowLine = "";
		getline(cin, rowLine);
		istringstream lineStream(rowLine);

		string element;

		while (lineStream >> element)
		{
			int num = stoi(element);
			inputRow.push_back(num);
		}

		numMatrix2.push_back(inputRow);
	}

	if (numMatrix1==numMatrix2)
	{
		cout << "equal";

	}
	else
	{
		cout << "not equal";
	}

	return 0;
}
