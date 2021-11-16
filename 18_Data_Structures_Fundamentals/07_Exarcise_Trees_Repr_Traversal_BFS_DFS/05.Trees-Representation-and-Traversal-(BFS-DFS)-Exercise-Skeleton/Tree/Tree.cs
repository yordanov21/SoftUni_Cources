namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        private string stringbilder;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this._children = children.ToList();

            //// also initailizating of the _children can make with the code below
            //this._children = new List<Tree<T>>();
            //foreach (var child in children)
            //{
            //    this.AddChild(child);
            //    child.AddParent(this);
            //}
        }

        public Tree()
        {
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return this.getTreeAsStringDFS(0).TrimEnd();
        }

        public string getTreeAsStringDFS(int level = 0)
        {

            var result = new string(' ', level) + this.Key + "\r\n";

            Console.WriteLine(stringbilder);
            foreach (var child in _children)
            {
                result += child.getTreeAsStringDFS(level + 2);
            }

            return result;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            int deepIdx = 0;
            var root = this;
            var deepNode = GetDeepestLeftMostNodeDFS(this, ref deepIdx, ref root);
            Console.WriteLine(deepNode.Key);
            return deepNode;
        }

        public Tree<T> GetDeepestLeftMostNodeDFS(Tree<T> node, 
                                                 ref int deepestIdx, 
                                                 ref Tree<T> deepCurrentNode, 
                                                 int deepIdx = 0)
        {
            Dictionary<int, Tree<T>> DEEPSES_NODES = new Dictionary<int, Tree<T>>();
            //var deepNode = deepCurrentNode;

            //  Console.WriteLine("CURRENT NODE: " + node.Key);
            if (node.Children.Count == 0)
            {
                return deepCurrentNode;
            }

            foreach (var child in node.Children)
            {
                if (child.Children.Count == 0)
                {
                    // Console.WriteLine("                     deepIdx: " + deepIdx);
                    //  Console.WriteLine("                     deepestIdx: " + deepestIdx);
                    if (deepestIdx < deepIdx)
                    {
                        deepestIdx = deepIdx;

                        deepCurrentNode = child;

                        DEEPSES_NODES.Add(deepestIdx, deepCurrentNode);
                        //Console.WriteLine("*******************");
                        //Console.WriteLine("DeepNode key: " + deepCurrentNode.Key);
                        //Console.WriteLine("deepIdx: " + deepIdx);
                        //Console.WriteLine("deepestIdx: " + deepestIdx);
                        //Console.WriteLine("*******************");

                        
                    }


                }

                this.GetDeepestLeftMostNodeDFS(child, ref deepestIdx, ref deepCurrentNode, deepIdx + 1);
            }

           // Console.WriteLine("цлицк лцикца");
          //  Console.WriteLine("DeepNode key: " + deepCurrentNode.Key);
            // Console.WriteLine("DeepNode keyyyyyyyyyyyyyyyyy: " + deepNode.Key);
            return deepCurrentNode;
        }

        public List<T> GetLeafKeys()
        {
            var leafNodes = this.getLeafNodes();

            return leafNodes.Select(x => x.Key).ToList();
        }

        //by BFS with queue
        public List<Tree<T>> getLeafNodes()
        {
            List<Tree<T>> leafNodes = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (node.Children.Count == 0)
                {
                    leafNodes.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return leafNodes;
        }

        public List<T> GetMiddleKeys()
        {
            var leafNodes = this.getMiddleNode();

            return leafNodes.Select(x => x.Key).ToList();
        }

        public List<Tree<T>> getMiddleNode()
        {
            List<Tree<T>> leafNodes = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (node.Parent != null && node.Children.Count != 0)
                {
                    leafNodes.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return leafNodes;
        }

        public List<T> GetLongestPath()
        {
            var deepestNode = GetDeepestLeftomostNode();

            var longestPath = new List<T>();

            while(deepestNode != null)
            {
                longestPath.Add(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }

            longestPath.Reverse();
            return longestPath;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            // start from the leaf first, but other 
            var leafNodes = this.getLeafNodes();
            List<List<T>> resultList = new List<List<T>>();

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                var currentNodes = new List<T>();

                var currentSum = 0;

                while (node != null)
                {
                    currentNodes.Add(node.Key);
                    currentSum += Convert.ToInt32(node.Key);
                    node = node.Parent;
                }

                if (currentSum == sum)
                {
                    currentNodes.Reverse();
                    resultList.Add(currentNodes);
                }
            }

            return resultList;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var roots = new List<Tree<T>>();

            SubTreeSumDFS(this, sum, roots);

            return roots;
        }

        private int SubTreeSumDFS(Tree<T> node, int targetSum, List<Tree<T>> roots)
        {
            var curretSum = Convert.ToInt32(node.Key);

            foreach (var child in node.Children)
            {
                curretSum += SubTreeSumDFS(child, targetSum, roots);
            }

            if(curretSum == targetSum)
            {
                roots.Add(node);
            }

            return curretSum;
        }

        private Tree<T> GetRoot()
        {
            var node = this._children.FirstOrDefault();

            // with this check we are shuare that the node is a root
            while (node.Parent != null)
            {
                node = node.Parent;
            }

            return node;
        }
    }
}
