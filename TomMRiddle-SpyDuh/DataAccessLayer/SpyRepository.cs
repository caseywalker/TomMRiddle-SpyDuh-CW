using System;
using System.Collections.Generic;
using System.Linq;
using TomMRiddle_SpyDuh.Models;

namespace TomMRiddle_SpyDuh.DataAccessLayer
{
  public class SpyRepository
  {
    public SpyRepository()
    {

    }
    static List<Spy> _spies = new List<Spy>();
        
        // GetAll() return _spies field
        internal IEnumerable<Spy> GetAll()
        {
            return _spies;
        }

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
