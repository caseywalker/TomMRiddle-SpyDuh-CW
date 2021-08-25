using System;
using System.Collections.Generic;
using System.Linq;
using TomMRiddle_SpyDuh.Models;

namespace TomMRiddle_SpyDuh.DataAccessLayer
{
  public class SpyRepository
  {
    static List<Spy> _spies = new List<Spy>
    {
      new Spy
      {
        SpyID = Guid.NewGuid(),
        Details = "Spy does good job",
        SpyBackground = "Spy been doin this a long time",
        LSTSkills = new List<string>
        {
          "Spying",
          "Plotting"
        },
        SpyServices = new List<string>
        {
          "Espionage",
          "Political take-over"
        }
      },
      new Spy
      {
        SpyID = Guid.NewGuid(),
        Details = "Spy does decent job",
        SpyBackground = "Spy been doin this a little time",
        LSTSkills = new List<string>
        {
          "Spying",
          "Infiltrating"
        },
        SpyServices = new List<string>
        {
          "Trapping",
          "Influence"
        }
      }
    };

    public List<Spy> GetAll()
    {
      return _spies;
    }

    internal void AddSpy(Spy newSpy)
    {
      newSpy.SpyID = Guid.NewGuid();
      _spies.Add(newSpy);
    }

    //internal void GetSpy(string newSpy)
    //{
    //  newSpy.SpyID = Guid.NewGuid();
    //  _spies.Add(newSpy);
    //}

  }
}
