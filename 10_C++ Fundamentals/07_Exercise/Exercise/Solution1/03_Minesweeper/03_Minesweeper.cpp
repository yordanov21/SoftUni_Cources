#include<iostream>
#include<vector>
using namespace std;

int main() {

	int inputMatrixRows, inputMatrixCols;
	cin >> inputMatrixRows >> inputMatrixCols;

	vector<vector<char> > inputMatrix;
	for (int row = 0; row < inputMatrixRows; row++)
	{
		vector<char> inputRow;
		string element;
		cin >> element;
		for (int col = 0; col < inputMatrixCols; col++)
		{
			inputRow.push_back(element[col]);
		}

		inputMatrix.push_back(inputRow);
	}

	vector<vector<int> > outputMatrix;
	for (int row = 0; row < inputMatrixRows; row++)
	{
		vector<int> outputRow;
		for (int col = 0; col < inputMatrixCols; col++)
		{

			outputRow.push_back(0);
		}

		outputMatrix.push_back(outputRow);
	}

	cout << "The matrix you typed in:" << endl;

	for (int row = 0; row < inputMatrixRows; row++)
	{
		for (int col = 0; col < inputMatrixCols; col++)
		{
			cout << inputMatrix[row][col] << " ";
		}
		cout << endl;
	}

	for (int row = 0; row < inputMatrixRows; row++)
	{
		for (int col = 0; col < inputMatrixCols; col++)
		{
			char symbol = inputMatrix[row][col];
			if (symbol == '!')
			{
				for (int currentRow = (row > 0 ? row - 1 : 0); currentRow <=((row< inputMatrixRows-1)? row + 1:row); currentRow++)
				{
					for (int currentCol = (col > 0 ? col - 1 : 0); currentCol <= ((col < inputMatrixCols - 1) ? col + 1 : col); currentCol++)
					{
						outputMatrix[currentRow][currentCol]++;
					}
				}
			}

		}

	}

	cout << "The mine matrix:" << endl;

	for (int row = 0; row < inputMatrixRows; row++)
	{
		for (int col = 0; col < inputMatrixCols; col++)
		{
			cout << outputMatrix[row][col] << " ";
		}
		cout << endl;
	}

	return 0;
}