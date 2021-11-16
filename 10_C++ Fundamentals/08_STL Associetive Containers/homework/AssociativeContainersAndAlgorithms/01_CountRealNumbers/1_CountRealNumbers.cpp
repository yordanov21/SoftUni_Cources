#include <iostream>
#include <string>
#include <sstream>  
#include <utility>
#include <map>

int main()
{
	using namespace std;

	string line = "";
	getline(cin, line);
	istringstream lineStream(line);

	string element;
	map <float, int> numbers;

	float num;
	while (lineStream >> element)
	{
		num = stof(element);
		if (numbers.find(num) == numbers.end())
		{
			numbers.insert({ num, 1 });
		}
		else
		{
			numbers[num]++;
		}
	}

	for (pair<float, int> number : numbers)
	{
		cout << number.first << " -> " << number.second << endl;
	}
}