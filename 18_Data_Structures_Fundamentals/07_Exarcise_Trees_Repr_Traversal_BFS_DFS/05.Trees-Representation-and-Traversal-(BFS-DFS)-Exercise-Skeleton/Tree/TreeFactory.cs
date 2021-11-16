namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                var lineArgs = line.Split(' ').Select(int.Parse).ToArray();

                this.CreateNodeByKey(lineArgs[0]);
                this.CreateNodeByKey(lineArgs[1]);

                this.AddEdge(lineArgs[0], lineArgs[1]);
            }

            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            Tree<int> node = null;

            if (!this.nodesBykeys.ContainsKey(key))
            {
                node = new Tree<int>(key);
                this.nodesBykeys.Add(key, node);
            }

            return node;
        }

        public void AddEdge(int parent, int child)
        {
            this.nodesBykeys[parent].AddChild(this.nodesBykeys[child]);
            this.nodesBykeys[child].AddParent(this.nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            var node = this.nodesBykeys.FirstOrDefault().Value;
            
            // with this check we are shuare that the node is a root
            while(node.Parent != null)
            {
                node = node.Parent;
            }

            return node;
        }
    }
}
