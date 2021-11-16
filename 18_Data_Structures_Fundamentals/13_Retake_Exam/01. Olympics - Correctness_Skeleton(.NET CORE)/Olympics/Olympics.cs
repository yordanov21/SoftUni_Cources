using System;
using System.Collections.Generic;
using System.Linq;

public class Olympics : IOlympics
{
    private SortedDictionary<int, Competition> _competitions;
    private SortedDictionary<int, Competitor> _competitors;

    public Olympics()
    {
        this._competitions = new SortedDictionary<int, Competition>();
        this._competitors = new SortedDictionary<int, Competitor>();
    }

    //you have to register a new competition.If there is already a competition with that id, return ArgumentException
    public void AddCompetition(int id, string name, int participantsLimit)
    {
        if (this._competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        var competition = new Competition(name, id, participantsLimit);
        this._competitions.Add(id, competition);
    }

    //you have to register a new competitor.If there is already a competitor with that id, return ArgumentException
    public void AddCompetitor(int id, string name)
    {
        if (this._competitors.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        var competitor = new Competitor(id, name);
        this._competitors.Add(id, competitor);
    }

    // search for the given competitor and the given competition and add the competitor with his score to the given competition.
    //If there are no such competitor or competition throw ArgumentException
    public void Compete(int competitorId, int competitionId)
    {

        if (!this._competitors.ContainsKey(competitorId))
        {
            throw new ArgumentException();
        }

        if (!this._competitions.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        this._competitors[competitorId].TotalScore += this._competitions[competitionId].Score;
        var temp = this._competitors[competitorId];

        this._competitions[competitionId].Competitors.Add(temp);
    }

    //return count of competitions
    public int CompetitionsCount()
    {
        return this._competitions.Count;
    }

    //return count of registered competitors
    public int CompetitorsCount()
    {
        return this._competitors.Count;
    }

    //Checks if a competitor is present in the competition.
    public bool Contains(int competitionId, Competitor comp)
    {
        if (!this._competitions.ContainsKey(competitionId))
        {
             throw new ArgumentException();
        }

        foreach (var competitor in this._competitions[competitionId].Competitors)
        {
            if (competitor.Name == comp.Name && competitor.Id == comp.Id)
            {
                return true;
            }
        }

        return false;
    }

    //search for the competitor in the competition and remove him from the competition.
    //Decrease the points of the competitor with the points of the current race.
    //If there are no such competitor or competition throw ArgumentException
    public void Disqualify(int competitionId, int competitorId)
    {
        if (!this._competitors.ContainsKey(competitorId))
        {
            throw new ArgumentException();
        }

        if (!this._competitions.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        this._competitions[competitionId].Competitors.Remove(this._competitors[competitorId]);

        this._competitors[competitorId].TotalScore -= this._competitions[competitionId].Score;
    }

    //find all competitors which have total score between the given start exclusive and end inclusive.
    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        List<Competitor> temp = new List<Competitor>();

        //foreach (var competitor in this._competitors)
        //{
        //    if (competitor.Value.TotalScore > min && competitor.Value.TotalScore < max)
        //    {
        //        temp.Add(competitor.Value);
        //    }
        //}

       var t = _competitors.Where(x => x.Value.TotalScore > min && x.Value.TotalScore < max).OrderBy(x => x.Value.Id);

        foreach (var item in t)
        {
            temp.Add(item.Value);
        }
        return temp;
    }

    //return all competitors with the provided name ordered by their id’s.
    //If there is no competitor with the given name return ArgumentException
    public IEnumerable<Competitor> GetByName(string name)
    {
        List<Competitor> temp = new List<Competitor>();

        foreach (var competitor in this._competitors)
        {
            if (competitor.Value.Name == name)
            {
                temp.Add(competitor.Value);
            }
        }

        if (temp.Count == 0)
        {
            throw new ArgumentException();
        }

        return temp;
    }

    //return the competition with the given id.If there is no such throw IllegalArgumentException
    public Competition GetCompetition(int id)
    {
        if (!this._competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        return this._competitions[id];
    }


    //Returns a list of contestants that have name lengths between the 2 parameters inclusive and order them by id.
    //If there aren’t any return empty collection.
    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        List<Competitor> temp = new List<Competitor>();

        foreach (var competitor in this._competitors)
        {
            if (competitor.Value.Name.Length >= min && competitor.Value.Name.Length <= max)
            {
                temp.Add(competitor.Value);
            }
        }

        return temp;
    }
}