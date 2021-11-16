#include <iostream>
#include <string>
#include <sstream>  
#include <vector>
#include <numeric>
#include <algorithm>   // std::min_element, std::max_element

using namespace std;

int main() {

    string line = "";
    getline(cin, line);
    istringstream lineStream(line);

    string element;

    vector<int> numbers;
    vector<string> charackters;

    while (lineStream >> element)
    {
        string currentNumberAsString="";
        bool numChek = false;
        for (size_t i = 0; i < element.size(); i++)
        {
            if (isdigit(element[i]))
            {
                currentNumberAsString.push_back(element[i]);
            }
        }

        if (currentNumberAsString.size() > 0) {
            int currentNumber = stoi(currentNumberAsString);
            numbers.push_back(currentNumber);
        }
        
    }

    cout << *max_element(numbers.begin(), numbers.end());
    return 0;
}
