#include <iostream>
#include <vector>
#include <stdlib.h>
#include <time.h>

using namespace std;

string randomString()
{
	string res = "";

	srand(time(0));

	for (int i = 0; i < 18; i++) {
		int randomNum = rand() % 94 + 33;
		char symbol = randomNum;
		res = res + symbol;
	}

	return res;
}

int main()
{

	int num = 0;
	cin >> num;

	for (int i = 97; i < 97+num; ++i)
	{
		for (int j = 97; j < 97 + num; ++j)
		{
			for (int k = 97; k < 97 + num; ++k)
			{
				cout << (char)i << (char)j << (char)k << "\n";
			}
		}
	}

	return 0;
}