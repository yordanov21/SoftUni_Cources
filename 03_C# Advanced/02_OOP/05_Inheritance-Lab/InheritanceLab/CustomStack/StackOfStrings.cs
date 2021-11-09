using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;

        public StackOfStrings()
        {
            this.stack = new Stack<string>();
        }
        public bool IsEmpty()
        {
            if (stack.Any())
            {
                return false;
            }
            return true;
        }
        public void AddRange(string element)
        {
           stack.Push(element);
        }

    }
}
