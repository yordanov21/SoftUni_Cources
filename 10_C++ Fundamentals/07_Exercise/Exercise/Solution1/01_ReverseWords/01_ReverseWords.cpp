#include<iostream>
#include<string>  // for getline();
#include<numeric>
#include<sstream>
#include <vector>
#include <list>
#include <stack>

using namespace std;

int main() 
{
	list<string> output;

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
			output.push_back(element);
		}
	}

	if (output.empty())
	{
		cout << "\"\" empty";
	}
	else
	{
		output.reverse();
		for (auto const& v : output)
			std::cout << v << " ";
	}

	return 0;
}