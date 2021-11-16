#include <iostream>
#include <string>
#include <sstream>  
#include <utility>
#include <map>
#include <list>
#include <algorithm>

using namespace std;

int main()
{
	string line = "";
	getline(cin, line);
	istringstream lineStream(line);
	string element;
	list<int> elements;

	while (lineStream >> element)
	{
		int num = stoi(element);
		int squareNum = sqrt(num);
		if (squareNum*squareNum==num) 
		{
			elements.push_back(num);
		}	
	}

	elements.sort(greater<int>());
	//print result
	string separator = "";
	for (auto it = elements.begin(); it != elements.end(); ++it)
	{
		cout << separator << *it;
		separator = " ";
	}
	cout << endl;
}