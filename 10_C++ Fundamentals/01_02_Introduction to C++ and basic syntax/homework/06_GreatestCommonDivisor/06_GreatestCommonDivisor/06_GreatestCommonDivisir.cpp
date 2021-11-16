#include<iostream>
#include <cmath>
using namespace std;

int gcd(int a, int b)
{
	if (a == 0)
	{
		return b;
	}
	return gcd(b % a, a);
}

int main() {
	int numberOne;
	int numberTwo;

	cin >> numberOne >> numberTwo;

	int gsdNUmber = gcd(numberOne, numberTwo);
	cout << gsdNUmber;

	return 0;
}


//long long int  factorial(int n);
//
//int main()
//{
//    int n;
//
//    cout << "Enter a positive integer: ";
//    cin >> n;
//    long long int factorialNumber= factorial(n);
//    int trailingZeros = 0;
//    while (true)
//    {
//        if (factorialNumber % 10 == 0) 
//        {
//            trailingZeros++;
//            factorialNumber = factorialNumber / 10;
//        }
//        else
//        {
//            break;
//        }
//      
//    }
//    cout << "Factorial of " << n << " = " << factorialNumber;
//    cout << "Trailing Zeroes " << n << " = " << trailingZeros++;;
//
//    return 0;
//}
//
//long long int  factorial(int n)
//{
//
//    if (n > 1) 
//    {
//        return n * factorial(n - 1);
//    }
//
//        return 1;
//    
//}




