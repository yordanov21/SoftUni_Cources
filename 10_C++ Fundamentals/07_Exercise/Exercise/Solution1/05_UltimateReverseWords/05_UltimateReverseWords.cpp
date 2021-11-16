#include<iostream>
#include<string>  // for getline();
#include<numeric>
#include<sstream>
#include <vector>
#include <list>

using namespace std;

int main() {


	vector<string> textInput;

	while (true)
	{
		string rowLine = "";
		getline(cin, rowLine);
		if (rowLine == "end")
		{
			break;
		}

		istringstream lineStream(rowLine);
		string element;
		while (lineStream >> element)
		{
			textInput.push_back(element);
		}
	}

	int range = textInput.size() / 2;
	int SIZE = textInput.size();
	for (int i = 0; i < SIZE-1; i++)
	{
		string firstWord = textInput[i];
		int jj = i;
		for (int j = i+1; j < SIZE-1; j++)
		{
			int seconWordIndex = SIZE - 1-jj;
			string secondWord = textInput[seconWordIndex];
			char lastCharFirstWord=NULL;
			char lastCharSecondWord=NULL;
			if (!isalpha(firstWord[firstWord.size() - 1]))
			{
				lastCharFirstWord = firstWord[firstWord.size() - 1];
				firstWord.pop_back();
			}

			if (!isalpha(secondWord[secondWord.size() - 1]))
			{
				lastCharSecondWord = secondWord[secondWord.size() - 1];
				secondWord.pop_back();
			}

			if (firstWord.size() == secondWord.size())
			{
				if (lastCharFirstWord!=NULL)
				{
					secondWord.push_back(lastCharFirstWord);
				}

				if (lastCharSecondWord != NULL)
				{
					firstWord.push_back(lastCharSecondWord);
				}
				textInput[i] = secondWord;
				textInput[seconWordIndex] = firstWord;
				break;
				
			}
			else if(!lastCharFirstWord!=NULL)
			{
				firstWord.push_back(lastCharFirstWord);
				
			}
			else if (!lastCharSecondWord!=NULL)
			{
				secondWord.push_back(lastCharSecondWord);
			}
			jj++;
		}
		
		
	}

	for (auto const& v : textInput)
		std::cout << v << " ";


	return 0;
}