using System;
using System.Collections.Generic;
using System.Linq;
using TomMRiddle_SpyDuh.Models;

namespace TomMRiddle_SpyDuh.DataAccessLayer
{
  public class SpyRepository
  {
    static List<Spy> _spies = new List<Spy>();

    // GetAll() return _spies field
    internal IEnumerable<Spy> GetAll()
    {
      var tempSpies = _spies;
      return tempSpies;
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
      var temp =  _spies.FirstOrDefault(spy => spy.SpyID == spyID);
      return temp;

      //return _spies.FirstOrDefault(spy => spy.SpyID == spyID);
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
