#include <iostream>
#include <vector>
#include <ostream>
#include <iostream>

void print(int n) {
	std::cout << n << std::endl;
}

int main() {
	using namespace std;

	int number = 42;
	char cStr[] = "I'm a C-String";
	const char* otherCStr = "I'm another C-String";

	int* numberPtr = &number;
	const void* p;

	p = numberPtr;
	cout << p << endl;

	p = &number;
	cout << p << endl;

	p = cStr;
	cout << cStr << " " << p << endl; // cStr will be printed as a string, p as an address

	p = otherCStr;
	cout << otherCStr << " " << p << endl; // otherCStr will be printed as a string, p as an address

	p = print;
	cout << p << endl; // address to the function

	return 0;
}