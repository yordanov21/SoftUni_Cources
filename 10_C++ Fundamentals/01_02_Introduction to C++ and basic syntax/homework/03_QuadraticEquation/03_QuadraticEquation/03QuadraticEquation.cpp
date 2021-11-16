#include<iostream>
#include <cmath>
using namespace std;

int main() {
	float a;
	float b;
	float c;

	cin >> a >> b >> c;

	float discriminant = b * b - 4 * a * c;
	float rootOne = (-b + sqrt(discriminant)) / (2 * a);
	float rootTwo = (-b - sqrt(discriminant)) / (2 * a);

	if (discriminant<0)
	{
		cout << "no roots" << endl;
	}
	else 
	{
		if (rootOne == rootTwo)
		{
			cout << rootOne << endl;
		}
		else
		{
			cout << rootOne << " " << rootTwo << endl;
		}
		
	}
	return 0;
}