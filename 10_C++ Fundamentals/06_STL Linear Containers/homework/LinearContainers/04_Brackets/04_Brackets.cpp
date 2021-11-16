#include <iostream>
#include<string>  // for getline();
#include <stack>

int main()
{
    std::stack<char> brackets;
    std::string input;

    std::getline(std::cin, input);

    bool isValid = true;

    for (char i : input)
    {
        switch (i)
        {
        case '(':
            brackets.push(')');
            break;
        case '{':
            brackets.push('}');
            break;
        case '[':
            brackets.push(']');
            break;
        case ')':
        case '}':
        case ']':
            if (brackets.empty() || brackets.top() != i)
            {
                isValid = false;
            }
            else
            {
                brackets.pop();
            }
            break;
        default:
            break;
        }

        if (!isValid)
        {
            break;
        }
    }

    if (isValid && brackets.empty())
    {
        std::cout << "valid" << std::endl;
    }
    else
    {
        std::cout << "invalid" << std::endl;
    }

    return 0;
}