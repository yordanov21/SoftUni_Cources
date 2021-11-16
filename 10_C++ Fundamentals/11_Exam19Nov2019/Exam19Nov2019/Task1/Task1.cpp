#include <iostream>
#include <vector>
#include <sstream>

using namespace std;
int main()
{
	int lines = 0;
	cin >> lines;
	vector <string> interview;

	for (size_t i = 0; i <= lines; i++)
	{
		string line = "";
		getline(cin, line);
		istringstream lineStream(line);
		string element;
		while (lineStream>> element)
		{
			if (interview.size() == 0) {
				interview.push_back(element);
			}
			else if(interview[interview.size()-1]!=element)
			{
				interview.push_back(element);
			}
		}
		
	}

	for (size_t i = 0; i < interview.size(); i++)
	{
		cout << interview[i] << " ";
	}
}

