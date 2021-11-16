#include <iostream>
#include <vector>
#include <stdlib.h>
#include <time.h>

using namespace std;

int main()
{
	string numberAsString = "";
	cin >> numberAsString;

	int sumEvens = 0;
	int sumOdds = 0;

	int sizeOf = numberAsString.size();
	for (int i = 0; i < sizeOf; i++)
	{
		if (isdigit(numberAsString[i]))
		{
			int currentdigit = (int)numberAsString[i]-48;
			if (currentdigit % 2 == 0)
			{
				sumEvens += currentdigit;
			}
			else
			{
				sumOdds += currentdigit;
			}
		}
		
	}

	cout << "Sum of Evens: " << sumEvens;
	cout << "\nSum of Odds: " << sumOdds;
	cout << "\nResult: " << sumEvens * sumOdds;
}