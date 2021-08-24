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

        // Add newSpy Method
        internal void Add(Spy newSpy)
        {
            newSpy.SpyID = Guid.NewGuid();

            _spies.Add(newSpy);
        }


        // Get by Id Method
        internal Spy GetById(Guid spyId)
        {
            return _spies.FirstOrDefault(spy => spy.SpyID == spyId);
        }

  }
}
