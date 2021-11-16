#include<iostream>
#include<vector>
using namespace std;

int main() {
  
    int inputMatrixRows, inputMatrixCols;
    cin >> inputMatrixRows >> inputMatrixCols;

    vector<vector<int> > inputMatrix;
    for (int row = 0; row < inputMatrixRows; row++) {
        vector<int> inputRow;
        for (int col = 0; col < inputMatrixCols; col++) {
            int element;
            cin >> element;
            inputRow.push_back(element);
        }

        inputMatrix.push_back(inputRow);
    }

    int searchedNum;

    cin >> searchedNum;
    bool foundIt = false;
    for (int row = 0; row < inputMatrixRows; row++) {
        for (int col = 0; col < inputMatrixCols; col++) {
            if (inputMatrix[row][col] == searchedNum)
            {
                cout << row << ' ' << col << endl;
                foundIt = true;
            }
            
        }

    }

    if (!foundIt) 
    {
        cout << "not found";
    }
   
    return 0;
}
