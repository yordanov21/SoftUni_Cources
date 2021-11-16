#include <iostream>
#include <vector>
#include <stdlib.h>
#include <time.h>

using namespace std;

string returnNumberAsString(int number)
{
	string result = "";
	switch (number)
	{
	case 1: result = "one";
		break;
	case 2: result = "two";
		break;
	case 3: result = "three";
		break;
	case 4: result = "four";
		break;
	case 5: result = "five";
		break;
	case 6: result = "six";
		break;
	case 7: result = "seven";
		break;
	case 8: result = "eigth";
		break;
	case 9: result = "nine";
		break;
	default:
		break;
	}

	return result;
}

string returnNumberAsString10to19(int number)
{
	string result = "";
	switch (number)
	{
	case 10: result = "ten";
		break;
	case 11: result = "eleven";
		break;
	case 12: result = "twelve";
		break;
	case 13: result = "thirteen";
		break;
	case 14: result = "fourteen";
		break;
	case 15: result = "fifteen";
		break;
	case 16: result = "sixteen";
		break;
	case 17: result = "seventeen";
		break;
	case 18: result = "eigthteen";
		break;
	case 19: result = "nineteen";
		break;
	default:
		break;
	}

	return result;
}

string returnDecNumberAsString(int number)
{
	string result = "";
	switch (number)
	{

	case 2: result = "twenty";
		break;
	case 3: result = "thirty";
		break;
	case 4: result = "fourty";
		break;
	case 5: result = "fifty";
		break;
	case 6: result = "sixty";
		break;
	case 7: result = "seventy";
		break;
	case 8: result = "eigthty";
		break;
	case 9: result = "ninety";
		break;
	default:
		break;
	}

	return result;
}

void returnHundreds(int num)
{

	//int dec = num / 10;
	int digit = num % 10;
	int decimal = num / 10;
	int dec = decimal % 10;
	int hundreds = decimal / 10;
	if (dec == 0)
	{
		cout << returnNumberAsString(hundreds) << " hundred " << returnNumberAsString(digit);
	}
	else if (dec == 1)
	{
		cout << returnNumberAsString(hundreds) << " hundred " << returnNumberAsString10to19(num - hundreds * 100);
	}
	else
	{
		cout << returnNumberAsString(hundreds) << " hundred " << returnDecNumberAsString(dec) << " " << returnNumberAsString(digit);
	}

}

int main()
{

	int num = 0;
	cin >> num;
	if (num == 0)
	{
		cout << "zero";
	}
	else if (num < 10)
	{
		cout << returnNumberAsString(num);
	}
	else if (num < 20)
	{
		cout << returnNumberAsString10to19(num);
	}
	else if (num < 100)
	{
		int digit = num % 10;
		int dec = num / 10;

		cout << returnDecNumberAsString(dec) << " " << returnNumberAsString(digit);
	}
	else if (num < 1000)
	{
		returnHundreds(num);
	}
	else if (num < 10000)
	{

		int thousands = num / 1000;
		int hundred = num % 1000;
		if (hundred < 10) 
		{
			cout << returnNumberAsString(thousands) << " thousand ";
			cout << returnNumberAsString(hundred);
		}
	    else if (hundred < 20) 
		{
			cout << returnNumberAsString(thousands) << " thousand ";
			cout << returnNumberAsString10to19(hundred);
		}
		else if (hundred<100)
		{
			cout << returnNumberAsString(thousands) << " thousand ";
			int digit = hundred % 10;
			int dec = hundred / 10;

			cout << returnDecNumberAsString(dec) << " " << returnNumberAsString(digit);
		}
		else 
		{
			cout << returnNumberAsString(thousands) << " thousand ";
			returnHundreds(hundred);
		}
	}
	else
	{
		cout << "To big number";
	}

	return 0;
}