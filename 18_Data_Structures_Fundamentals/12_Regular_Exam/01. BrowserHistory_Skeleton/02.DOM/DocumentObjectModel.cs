namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            var document = new HtmlElement(ElementType.Document,
                new HtmlElement(ElementType.Html,
                    new HtmlElement(ElementType.Head),
                    new HtmlElement(ElementType.Body)));

            this.Root = document;
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while(queue.Count>0)
            {
                var current = queue.Dequeue();

                if(current.Type == type)
                {
                    return current;
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public IHtmlElement DFSElement(IHtmlElement node, ElementType type)
        {

            foreach (var child in node.Children)
            {
                if(node.Type == type)
                {
                    return node;
                }

                DFSElement(child,type);
            }

            return null; 
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            return DFSList(this.Root, type);
        }

        private List<IHtmlElement> DFSList(IHtmlElement root, ElementType elementType)
        {
            var result = new List<IHtmlElement>();


            foreach (var child in root.Children)
            {
                result.AddRange(DFSList(child, elementType));
            }

            if (root.Type == elementType)
            {
                result.Add(root);
            }
            return result;
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == htmlElement)
                {
                    return true;
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return false;

           // return DFSContains(this.Root, htmlElement);
        }

        // dont work correct, investigate why
        public bool DFSContains(IHtmlElement node, IHtmlElement htmlElement)
        {

            foreach (var child in node.Children)
            {
                if (child == htmlElement)
                {
                    return true;
                }

                DFSContains(child, htmlElement);
            }

            return false;          
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            if (this.Contains(parent))
            {
                child.Parent = parent;
                parent.Children.Insert(0, child);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            if (this.Contains(parent))
            {
                child.Parent = parent;
                parent.Children.Add(child);
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public void Remove(IHtmlElement htmlElement)
        {
            if (!this.Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            var parent = htmlElement.Parent;

            parent.Children.Remove(htmlElement);

            // may be not needed
           // htmlElement.Children.Clear();
           // htmlElement.Parent = null;
        }

        public void RemoveAll(ElementType elementType)
        {
            //BFS way
            var result = new Queue<IHtmlElement>();

            result.Enqueue(this.Root);

            while(result.Count > 0)
            {
                var current = result.Dequeue();

                if(current.Type == elementType)
                {
                    var parent = current.Parent;
                    parent.Children.Remove(current);
                    // may be not needed
                    // htmlElement.Children.Clear();
                    // htmlElement.Parent = null;
                }

                foreach (var child in current.Children)
                {
                    result.Enqueue(child);
                }             
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            if(!this.Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            if (htmlElement.Attributes.ContainsKey(attrKey))
            {
                return false;
            }


            if (!htmlElement.Attributes.ContainsKey(attrKey))
            {
                htmlElement.Attributes.Add(attrKey, attrValue);
                return true;
            }

            return false;

            // work with this way too
            //DFSAddAttribute(this.Root, htmlElement, attrKey,attrValue);

            //return true;
        }

        public void DFSAddAttribute(IHtmlElement node, IHtmlElement htmlElement, string attrKey, string attrValue)
        {
            if(node == htmlElement)
            {
                node.Attributes.Add(attrKey, attrValue);
                return;
            }

            foreach (var child in node.Children)
            {
                DFSAddAttribute(child, htmlElement, attrKey, attrValue);
            }

        }


        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            if (!this.Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            if (htmlElement.Attributes.ContainsKey(attrKey))
            {
                htmlElement.Attributes.Remove(attrKey);
                return true;
            }

            return false;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();

                if(current.Attributes.ContainsKey("id"))
                {
                    if(current.Attributes["id"] == idValue)
                    {
                        return current;
                    }            
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }

            }

            return null;   
        }

        public IHtmlElement BFS(IHtmlElement root, string idValue)
        {
            List<IHtmlElement> list = new List<IHtmlElement>();

            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                list.Add(node);

                if(node.Attributes.ContainsKey(idValue))
                {
                    return node;
                }
       
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public override string ToString()
        {
            return DFSPrint(this.Root, 0);
        }

        private string DFSPrint(IHtmlElement root, int ofset)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{new string(' ', ofset)}{root.Type}");
            foreach (var child in root.Children)
            {
                sb.Append(DFSPrint(child, ofset + 2));
            }

            return sb.ToString();
        }
    }
}
