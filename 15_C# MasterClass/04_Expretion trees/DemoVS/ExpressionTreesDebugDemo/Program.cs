using System;
using System.Linq.Expressions;

namespace ExpressionTreesDebugDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, bool>> expr = num => num > 5;
        }
    }
}
