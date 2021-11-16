#include <iostream>
#include <string>
#include <sstream>  
#include <vector>
#include <numeric>

using namespace std;

bool isNumber(const std::string& str)
{
    char* ptr;
    strtol(str.c_str(), &ptr, 10);
    return *ptr == '\0';
}

int main() {

    string line = "";
    getline(cin, line);
    istringstream lineStream(line);

    string element;
   
    vector<int> numbers;
    vector<string> charackters;

    while (lineStream >> element)
    {
       
        if (isNumber(element))
        {
            int currentElement = stoi(element);
            numbers.push_back(currentElement);
        }
        else
        {
           charackters.push_back(element);
        }
    }

    int sum_of_elems = std::accumulate(numbers.begin(), numbers.end(), decltype(numbers)::value_type(0));

    cout << sum_of_elems << endl;
    for (auto i = charackters.begin(); i != charackters.end(); ++i)
        std::cout << *i << ' ';

    return 0;
}
