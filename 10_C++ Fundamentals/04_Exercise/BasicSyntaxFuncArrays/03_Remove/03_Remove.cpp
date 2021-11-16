#include <iostream>
#include <vector>
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

	//vtori nachin za populvane na vectora, no toi e po-baven, zashtoto po tozi nachin ne znaem size-a na vectora i toi 
	//shte trqbva da se preorazmerqva, a gore go znamem i napravo go vuvejdame 
	/*vector<int> vec2;
	for (int i = 0; i < size; ++i)
	{
		int num = 0;
		cin >> num;
		vec2.push_back(num);
	}*/

	int numToRemove = 0;
	cin >> numToRemove;

	int sizeVec = vec.size();
	for (int num : vec)
	{
		if (numToRemove != num) 
		{
			cout << num << " ";
		}
	}
}