#include<iostream>
#include<string>  // for getline();
#include<numeric>
#include<sstream>
#include <vector>
#include <list>

using namespace std;

int main() {


	string trainOneString = "";
	getline(cin, trainOneString);
	istringstream trainStream(trainOneString);
	string element;

	vector<int> trainOne;

	while (trainStream >> element)
	{
		int numberRailCar = stoi(element);
		trainOne.push_back(numberRailCar);
	}

	string trainTwoString = "";
	getline(cin, trainTwoString);
	istringstream trainStream2(trainTwoString);
	string element2;

	vector<int> trainTwo;

	while (trainStream2 >> element2)
	{
		int numberRailCar = stoi(element2);
		trainTwo.push_back(numberRailCar);
	}
	
	string trainTracks = "";
	list<int> trainNums;

	while (true)
	{
		int trainAVagon = trainOne[trainOne.size() - 1];
		int trainBVagon = trainTwo[trainTwo.size() - 1];

		if (trainAVagon < trainBVagon)
		{
			trainTracks.push_back('A');
			trainNums.push_back(trainAVagon);
			trainOne.pop_back();
		}
		else
		{
			trainTracks.push_back('B');
			trainNums.push_back(trainBVagon);
			trainTwo.pop_back();
		}

		if (trainOne.size() == 0 && trainTwo.size()==0)
		{
			break;
		}
		if (trainOne.size() == 0)
		{
			while (trainTwo.size() != 0)
			{
				trainBVagon = trainTwo[trainTwo.size() - 1];
				trainTracks.push_back('B');
				trainNums.push_back(trainBVagon);
				trainTwo.pop_back();
			}
			break;
		}
		if (trainTwo.size() == 0)
		{
			while (trainOne.size() != 0)
			{
			    trainAVagon = trainOne[trainOne.size() - 1];
				trainTracks.push_back('A');
				trainNums.push_back(trainAVagon);
				trainOne.pop_back();
			}
			break;
		}
	}

	cout << trainTracks << endl;
	// Reverse the vector 
	//reverse(trainNums.begin(), trainNums.end());
	trainNums.reverse();
	for (auto vagonNum = trainNums.begin(); vagonNum != trainNums.end(); ++vagonNum)
		std::cout << *vagonNum << ' ';

	return 0;
}