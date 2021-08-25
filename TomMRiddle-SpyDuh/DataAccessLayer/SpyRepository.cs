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

    // GetAll() return _spies field
    internal IEnumerable<Spy> GetAll()
    {
      return _spies;
    }

    // Add newSpy Method
    internal void AddSpy(Spy newSpy)
    {
      newSpy.SpyID = Guid.NewGuid();

      _spies.Add(newSpy);
    }

    // Get by ID Method
    internal Spy GetByID(Guid spyID)
    {
      return _spies.FirstOrDefault(spy => spy.SpyID == spyID);
    }

    internal IEnumerable<Spy> GetSpiesBySkill(string skill)
    {
      return _spies.Where(Spy => Spy.LSTSkills.Contains(skill));
    }

    internal IEnumerable<Spy> GetSpyFriends(Guid spyID)
    {
      return _spies.FirstOrDefault(spy => spy.SpyID == spyID).LSTFriendlySpies;
    }

    internal IEnumerable<Spy> GetSpyEnemies(Guid spyID)
    {
      return _spies.FirstOrDefault(spy => spy.SpyID == spyID).LSTEnemySpies;
    }

    internal IEnumerable<string> GetSpyAvailableSkils(Guid spyID)
    {
      return _spies.FirstOrDefault(spy => spy.SpyID == spyID).LSTSkills;
    }


  }
}
