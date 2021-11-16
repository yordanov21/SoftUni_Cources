using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[]
          {
                "7 19",
                "7 21",
                "7 14",
                "19 1",
                "19 12",
                "19 31",
                "14 23",
                "14 6"
          };

            var treeFactory = new TreeFactory();
            var tree = treeFactory.CreateTreeFromStrings(input);
            Console.WriteLine(tree.GetAsString());
            //  tree.GetDeepestLeftomostNode();
            Console.WriteLine("***********************************");
            Console.WriteLine(tree.GetLeafKeys());

            Console.WriteLine("***********************************");
            var list = tree.GetLongestPath();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
