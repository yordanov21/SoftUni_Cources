#include <iostream>
#include <string>
#include <sstream>  
#include <vector>
#include <numeric>
#include <algorithm>   // std::min_element, std::max_element

using namespace std;

struct compare {
	inline bool operator()(const std::string& first,
		const std::string& second) const
	{
		return first.size() > second.size();
	}
};

int main() {

	string line = "";
	getline(cin, line);
	istringstream lineStream(line);

	string element;

	vector<int> numbers;
	vector<string> strVector;

	while (lineStream >> element)
	{
		string currentString = "";

		for (size_t i = 0; i < element.size(); i++)
		{
			if (!isdigit(element[i]))
			{
				currentString.push_back(element[i]);
			}
		}

		if (currentString.size() > 0) {

			strVector.push_back(currentString);
		}

	}

	//sort alphabetically
	sort(strVector.begin(), strVector.end(), less<string>());
	// sort(strVector.begin(), strVector.end());  // doing the same 

	//sirting by length of a string elements of the vector 
	compare c;
	sort(strVector.begin(), strVector.end(), c);

	if (strVector.size() > 0)
	{
		cout << strVector[0];
	}
	else
	{
		cout << "no noise";
	}
	return 0;
}
