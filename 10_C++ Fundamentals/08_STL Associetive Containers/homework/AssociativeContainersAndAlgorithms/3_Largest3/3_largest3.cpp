#include <iostream>
#include <string>
#include <sstream>  
#include <utility>
#include <map>
#include <set>
#include <list>

int main()
{
	using namespace std;

	string line = "";
	getline(cin, line);
	istringstream lineStream(line);

	string element;
	list <float > numbers;

	float num;
	while (lineStream >> element)
	{
		num = stof(element);
		numbers.push_back(num);
	}
	numbers.sort(greater<float>());
	int count = 0;
	string separator = "";
	// using begin() to print set 
	for (auto it = numbers.begin(); it != numbers.end(); ++it)
	{ 
		if (count == 3)
		{
			break;
		}
		cout << separator << *it;
		separator = " ";
		count++;	
	}
		
	return 0;
}