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
	list<double> elements;


	while (lineStream >> element)
	{
		double num = stod(element);
		elements.push_back(num);
	}

	elements.sort();
	//print result
	string separator = "";
	for (auto it = elements.begin(); it != elements.end(); ++it)
	{
		cout << separator << *it;
		separator = " <= ";
	}
	cout << endl;
}