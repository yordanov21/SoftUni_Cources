namespace _01._BrowserHistory
{
    using _01._BrowserHistory.Interfaces;

    public class Link : ILink
    {
        public Link(string url, int loadingTime)
        {
            this.Url = url;
            this.LoadingTime = loadingTime;
        }

        public string Url { get; set; }
        public int LoadingTime { get; set; }

        public override string ToString()
        {
            return $"-- {this.Url} {this.LoadingTime}s";
        }

        //compareTo by time
        //public int CompareTo(object obj)
        //{
        //    var current = (ILink)obj;

        //    return current.LoadingTime - this.LoadingTime;
        //}

        // CompareTo by url
        public int CompareTo(ILink other)
        {
            if (this.Url.ToLower() == other.Url.ToLower())
            {
                return 0;
            }

            return -1;
        }


        // ovveride Equals to retur entity Id
        //public override bool Equals(object obj)
        //{
        //    if (obj is ILink)
        //    {
        //        var link = (ILink)obj;
        //        return link.LoadingTime == this.LoadingTime;
        //    }

        //    return false;
        //}
    }
}
