namespace _02.DOM.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
            this.Type = type;
            this.Children = children.ToList();

            this.Attributes = new Dictionary<string, string>();

            foreach(var child in this.Children)
            {
                child.Parent = this;
            }
        }

        public HtmlElement()
        {

        }
        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children { get; set; }

        public Dictionary<string, string> Attributes { get; }
    }
}
