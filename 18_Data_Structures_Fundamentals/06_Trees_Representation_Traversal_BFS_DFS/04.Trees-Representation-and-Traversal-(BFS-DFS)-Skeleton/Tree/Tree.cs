namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.isRootDeleted = false;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            this.isRootDeleted = false;

            foreach (Tree<T> child in children)
            {
                this.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }

        public bool isRootDeleted { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while(queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();

                result.Add(subtree.Value);

                foreach (Tree<T> child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();

            this.Dfs(this, result);

            return result;
        }

        // using recursion
        private void Dfs(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                this.Dfs(child, result);
            }

            result.Add(tree.Value);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var searchedNode = this.FildBfs(parentKey);

            CheckEmptyNode(searchedNode);

            searchedNode._children.Add(child);
          //  child.Parent = searchedNode;
        }

        private void CheckEmptyNode(object searchedNode)
        {
            if(searchedNode == null)
            {
                throw new ArgumentNullException();
            }
        }

        private Tree<T> FildBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();

                if(parentKey.Equals(subtree))
                {
                    return subtree;                
                }
          
            }

            return null;
        }

        public void RemoveNode(T nodeKey)
        {
            if(this._children.Count == 0)
            {
                this.Parent = null;
                return;
            }

            var searchedNode = this.FildBfs(nodeKey);
            CheckEmptyNode(searchedNode);

            foreach (var child in searchedNode.Children)
            {
                child.Parent = null;
            }

            searchedNode._children.Clear();

            Tree<T> searchedParent = searchedNode.Parent;

            if(searchedParent == null)
            {
                this.isRootDeleted = true;
            }
            else
            {
                searchedParent._children.Remove(searchedNode);
            }

            searchedNode.Value = default(T);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var searchedFirstNode = this.FildBfs(firstKey);
            var searchedSecondNode = this.FildBfs(secondKey);

            CheckEmptyNode(searchedFirstNode);
            CheckEmptyNode(searchedSecondNode);

            var firstNode = searchedFirstNode;
            var secondNode = searchedSecondNode;

            int idxOfFirst = searchedFirstNode._children.IndexOf(firstNode);
            int idxOfSecond = searchedSecondNode._children.IndexOf(secondNode);

            searchedFirstNode._children[idxOfFirst] = secondNode;
            searchedSecondNode._children[idxOfSecond] = firstNode;
            //var tempFirstNode = searchedFirstNode;
            //var tempSecondNode = searchedSecondNode;

            //searchedFirstNode.Parent = tempSecondNode;
            //searchedSecondNode.Parent = tempFirstNode;



        }
    }
}
