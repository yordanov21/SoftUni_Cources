namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private LinkedList<ILink> links;

        public BrowserHistory()
        {
            this.links = new LinkedList<ILink>();

        }
        public int Size => links.Count;

        public void Clear()
        {
            links.Clear();
        }

        public bool Contains(ILink link)
        {
            return links.Contains(link);
            //  return this.GetByUrl(link.Url) != null;
        }

        public ILink DeleteFirst()
        {
            ValidateIfEmpty();

            var link = links.Last;
            links.RemoveLast();

            return link.Value;
        }

        public ILink DeleteLast()
        {
            ValidateIfEmpty();

            var link = links.First;
            links.RemoveFirst();

            return link.Value;
        }

        public ILink GetByUrl(string url)
        {
            foreach (var link in links)
            {
                if (link.Url == url)
                {
                    return link;
                }
            }


            return null;

            //var node = this.links.First;

            //while (node != null)
            //{
            //    var nextNode = node.Next;
            //    if (node.Value.Url.ToLower().Contains(url.ToLower()))
            //    {
            //        return node.Value;
            //    }
            //    node = nextNode;
            //}

            ////foreach (var link in links)
            ////{
            ////    if(link.Url.ToLower() == url)
            ////    {
            ////        return link;
            ////    }
            ////}

            //return null;
        }

        public ILink LastVisited()
        {
            ValidateIfEmpty();

            return links.First.Value;
        }

        public void Open(ILink link)
        {
            links.AddFirst(link);
        }

        public int RemoveLinks(string url)
        {
            ValidateIfEmpty();

            var node = this.links.First;
            int counter = 0;

            while (node != null)
            {
                var nextNode = node.Next;

                if (node.Value.Url.Contains(url))
                {
                    this.links.Remove(node);
                    counter++;
                }

                node = nextNode;
            }

            if (counter == 0)
            {
                throw new InvalidOperationException("No link with URL");
            }

            return counter;
        }

        public ILink[] ToArray()
        {
            return this.links.ToArray();
        }

        public List<ILink> ToList()
        {
            return this.links.ToList();
        }

        public string ViewHistory()
        {
            if (this.Size == 0)
            {
                return "Browser history is empty!";
            }

            StringBuilder result = new StringBuilder();
            foreach (var link in links)
            {
                result.AppendLine(link.ToString());
            }

            return result.ToString();
        }

        private void ValidateIfEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Empty history!");
            }
        }
    }
}
