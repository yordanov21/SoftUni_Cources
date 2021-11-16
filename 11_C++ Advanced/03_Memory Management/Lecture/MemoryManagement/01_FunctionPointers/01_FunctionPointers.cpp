#include <iostream>
#include <vector>
#include <ostream>

//predefinate operator "<<" for ostream. 
//When we ride cout << vec; in the code below directly it print vec in predefinated format :) 
template<typename T>
std::ostream& operator <<(std::ostream& stream, const std::vector<T>& v) {
	for (T item : v) {
		stream << item << " ";
	}

	return stream;
}

bool isNegative(int number) {
	return number < 0;
}

bool isEven(int number) {
	return number % 2 == 0;
}

bool isBiggerThanThree(int number) {
	return number > 3;
}

//
std::vector<int> filter(const std::vector<int>& vec, bool(*shouldFilter)(int number)) {
	std::vector<int> filtered;

	for (const int element : vec) {
		if (shouldFilter(element)) {
			filtered.push_back(element);
		}
	}

	return filtered;
}
int main() {
	const std::vector<int> vec{ 1,-2,-6,2,3,4,5,6,7 };
	//std::cout << filter(vec, isNegative);
	return 0;
}