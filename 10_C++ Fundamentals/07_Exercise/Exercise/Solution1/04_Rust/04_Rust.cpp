#include<iostream>
#include<vector>
using namespace std;

int main() {

	const int inputMatrixRows = 10;
	const int inputMatrixCols = 10;

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

	int sycle;
	cin >> sycle;

	vector<vector<char> > outputMatrix = inputMatrix;

	for (int s = 0; s < sycle; ++s)
	{
		for (int row = 0; row < inputMatrixRows; row++)
		{
			for (int col = 0; col < inputMatrixCols; col++)
			{
				char symbol = inputMatrix[row][col];
				if (symbol == '!')
				{
					if (row > 0 && outputMatrix[row - 1][col]!='#')
					{

						outputMatrix[row - 1][col] = '!';
					}
					if (row < (inputMatrixRows - 1) && outputMatrix[row + 1][col]!='#')
					{
						outputMatrix[row + 1][col] = '!';
					}
					if (col > 0 && outputMatrix[row][col - 1]!='#')
					{
						outputMatrix[row][col - 1] = '!';
					}
					if (col < (inputMatrixCols - 1) && outputMatrix[row][col + 1]!='#')
					{
						outputMatrix[row][col + 1] = '!';
					}
				}
			}
		}

		inputMatrix = outputMatrix;
	}

	

	cout << "The Rust matrix:" << endl;

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