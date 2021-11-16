#include <iostream>
#include <string>
#include <sstream>  
#include <utility>
#include <map>
#include <set>
#include <algorithm>

using namespace std;

int main()
{
	string line = "";
	getline(cin, line);
	istringstream lineStream(line);
	string element;
	set<string> elements;


	while (lineStream >> element)
	{
		// using transform() function and ::tolower in STL 
		transform(element.begin(), element.end(), element.begin(), ::tolower);

		if (element.size()<5)
		{
			elements.insert(element);
		}
	
	}

	//print result
	string separator = "";
	for (auto it = elements.begin(); it != elements.end(); ++it)
	{
		cout << separator << *it;
		separator = ", ";
	}
	cout << endl;
}