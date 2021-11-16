#include <iostream>
#include <map>
#include <vector>

using namespace std;

int main()
{
	map <string, int> miners;
	vector <string> inputOrder;
	string resource;
	int quantity;

	while (std::cin >> resource && resource != "stop" && std::cin >> quantity)
	{

		// adding the resource -> quantity pair in the map or just updating the value of quantity
		miners[resource] += quantity;

		//cheking if this this resource appear for the first time
		if (miners[resource] == quantity)
		{
			inputOrder.push_back(resource);
		}
	}

	// printing the resource -> quantity pairs in the order of their first insertion
	for (vector<string>::iterator i = inputOrder.begin(); i != inputOrder.end(); i++)
	{
		cout << *i << " -> " << miners[*i] << endl;
	}

}