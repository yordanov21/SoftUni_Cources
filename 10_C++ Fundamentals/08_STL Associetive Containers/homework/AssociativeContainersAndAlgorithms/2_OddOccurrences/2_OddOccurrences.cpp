#include <iostream>
#include <string>
#include <sstream>  
#include <utility>
#include <map>
#include <unordered_map>
#include <algorithm>

using namespace std;

int main()
{
	string line = "";
	getline(cin, line);
	istringstream lineStream(line);
	string element;
	vector<pair<string, int> >elements;
	bool isExist = false;

	while (lineStream >> element)
	{
		// using transform() function and ::tolower in STL 
		transform(element.begin(), element.end(), element.begin(), ::tolower);

		if (isExist)
		{
			for (int i = 0; i < elements.size(); ++i)
			{
				if (elements[i].first == element)
				{
					elements[i].second++;
					isExist = true;
					break;
				}
				else
				{
					isExist = false;
				}
			}
		}
		if (!isExist)
		{
			elements.push_back({ element,1 });
			isExist = true;
		}
	}
	//print result
	string separator = "";
	for (int i = 0; i < elements.size(); ++i)
	{
		if (elements[i].second % 2 != 0)
		{
			cout << separator << elements[i].first;
			separator = ", ";
		}
	}
	cout << endl;
}

//raboteshto revhenie v djudge
//void make_lower(string& word)
//{
//	for (char& ch : word)
//		ch = tolower(ch);
//}
//
//int main()
//{
//	string line;
//	getline(cin, line);
//
//	istringstream iss(line);
//	string word;
//	using word_count = pair<string, int>;
//	vector<word_count> words;
//	while (getline(iss, word, ' '))
//	{
//		make_lower(word);
//		int i;
//		for (i = 0; i < words.size(); i++)
//			if (word == words[i].first)
//			{
//				words[i].second++;
//				break;
//			}
//		if (words.size() == i)
//			words.push_back(make_pair(word, 1));
//	}
//
//	string separator = "";
//	for (const auto& p : words)
//		if (p.second % 2 == 1)
//		{
//			cout << separator << p.first;
//			separator = ", ";
//		}
//	cout << endl;
//}