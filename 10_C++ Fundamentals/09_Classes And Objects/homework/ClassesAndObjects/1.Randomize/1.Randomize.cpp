#include <iostream>
#include <string>
#include <sstream>  
#include <utility>
#include <map>
#include <vector>
#include <algorithm>
#include <time.h>

using namespace std;

class Distance
{
public:
	vector<string> words;

	Distance(vector<string> words) {
		this->words = words;
	}

	void getShiftedSentence(int num)
	{	
		for (size_t i = 0; i < num; i++)
		{
			string word = words.back();
			words.pop_back();
			words.insert(words.begin(), word);
		}
	}

	void printWords()
	{
		for (auto it = words.begin(); it != words.end(); ++it)
		{
			cout << *it << endl;
		}		
	}
};

int main()
{
	//to get different random every time must to use srand()
	string line = "";
	getline(cin, line);
	istringstream lineStream(line);
	string element;
	vector<string> elements;
	
	srand(unsigned(time(0)));
	while (lineStream >> element)
	{
		elements.push_back(element);

	}

	Distance randwords(elements);
	int num = 0;
	cin >> num;
	randwords.getShiftedSentence(num);
	randwords.printWords();
}