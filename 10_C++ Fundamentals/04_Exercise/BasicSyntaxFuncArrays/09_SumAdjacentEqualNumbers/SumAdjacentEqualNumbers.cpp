#include <iostream>
#include <vector>
#include <stdlib.h>
#include <time.h>

using namespace std;

int main()
{
	int size = 0;
	cin >> size;

	vector<int> vec(size);
	for (int i = 0; i < size; ++i)
	{
		cin >> vec[i];
	}

	bool IsEqual = false;

	int sizeOf = vec.size();
	for (int i = 0; i < vec.size()-2; i=(IsEqual)?(i=((i>0)?--i:0)):++i)
	{

		int num1 = vec[i];
		int num2 = vec[i+1];
	
		if (num1 == num2)
		{
			IsEqual = true;
			int num = vec[i]+ vec[i + 1];
			vec.erase(vec.begin() + i);
			vec.erase(vec.begin() + i);

			std::vector<int>::iterator it;
			it = vec.begin()+i;
			vec.insert(it, num);
		}
		else
		{
			IsEqual = false;
		}
	}

	for (int num : vec) 
	{
		cout << num << " ";
	}
}