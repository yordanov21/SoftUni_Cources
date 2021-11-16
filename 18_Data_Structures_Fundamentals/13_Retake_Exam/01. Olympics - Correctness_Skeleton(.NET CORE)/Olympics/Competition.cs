using System;
using System.Collections;
using System.Collections.Generic;
//using System.Collections.IEnumerable;

public class Competition //: ICollection
{
    public Competition()
    {
    }

    public Competition(string name, int id, int score)
    {
        this.Name = name;
        this.Id = id;
        this.Score = score;
        this.Competitors = new List<Competitor>();
       
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public int Score { get; set; }

    public ICollection<Competitor> Competitors { get; set; }

    //public int Count => throw new NotImplementedException();

    //public bool IsSynchronized => throw new NotImplementedException();

    //public object SyncRoot => throw new NotImplementedException();

    //public void CopyTo(Array array, int index)
    //{
    //    throw new NotImplementedException();
    //}

    //public IEnumerator GetEnumerator()
    //{
    //    return ((IEnumerable)Competitors).GetEnumerator();
    //}
    // public List<Competitor> Competitors { get; set; }
}
