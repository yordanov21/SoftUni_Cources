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
	stack<string> output;

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
			output.push(element);
		}
	}

	if (output.empty())
	{
		cout << "\"\" empty";
	}
	else
	{
	
		while ((!output.empty()))
		{
			cout << output.top() << " ";
			output.pop();
		}
	}

	return 0;
}