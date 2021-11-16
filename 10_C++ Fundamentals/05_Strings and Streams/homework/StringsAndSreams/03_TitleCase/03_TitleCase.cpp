#include<iostream>
#include <cmath>
#include <vector>
#include <string>
using namespace std;

int main() {

	string line = "";
	getline(cin, line);

	if (line[0] <= 'z' && line[0] >= 'a')
	{
		line[0] = line[0] - 32;
	}

	for (size_t i = 1; i < line.size()-1; i++)
	{
		
		if (islower(line[i]) && !((line[i - 1] <= 'z' && line[i - 1] >= 'a') || (line[i - 1] <= 'Z' && line[i - 1] >= 'A')))
		{
			line[i] = line[i] - 32;
		}
	}

	cout << line;

	return 0;
}