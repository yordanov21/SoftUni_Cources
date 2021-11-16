#include <iostream>
#include <string>
#include <sstream>  
#include <utility>
#include <map>
#include <vector>
#include <algorithm>
#include <time.h>
#include <iomanip>

using namespace std;

class Sale
{
private:
	string town;
	string product;
	double price;
	double quantity;

	map <string, double> sales;
	vector <string> towns;

public:
	Sale(string town, string product, double price, double quantity) {
		this->town = town;
		this->product = product;
		this->price = price;
		this->quantity = quantity;
	}

	Sale() {
	
	}

	void getSale(string town, string product, double price, double quantity)
	{
		this->town = town;
		this->product = product;
		this->price = price;
		this->quantity = quantity;
		fillListIfSales();
	}

	void printResult() {
		for (auto it = sales.cbegin(); it != sales.cend(); ++it)
		{
			std::cout << it->first << " -> " << fixed << setprecision(2) << it->second << "\n";
		}
	}

private:
	void fillListIfSales() {
		//adding the resource->quantity pair in the map or just updating the value of quantity
		sales[town] += price * quantity;
	}
};

int main()
{
	int counter;
	cin >> counter;

	Sale sale;
	for (int i = 0; i < counter; i++)
	{
	
		string town;
		cin >> town;
		string product;
		cin >> product;
		string priceAsString;
		cin >> priceAsString;
		string quantityAsString;
		cin >> quantityAsString;

		double price = stod(priceAsString);
		double quantity = stod(quantityAsString);

		sale.getSale(town, product, price, quantity);
	}

	sale.printResult();
}