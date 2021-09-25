using System;
using System.Collections.Generic;

namespace TomMRiddle_SpyDuh.Models
{
  public class Spy
  {

    public string Name { get; set; }
    public Guid SpyID { get; set; }
    public string Details { get; set; }
    public string SpyBackground { get; set; }
    public List<SpySkills> LSTSkills { get; set; }
    public List<string> Skills { get; set; }
    public List<Guid> LSTFriendlySpies { get; set; } = new List<Guid>();
    public List<Guid> LSTEnemySpies { get; set; } = new List<Guid>();
    public List<string> SpyServices { get; set; }


    internal void AddSpyToFriendsList(Guid friendlySpyID)
    {
      LSTFriendlySpies.Add(friendlySpyID);
    }

    internal void AddSpyToEnemyList(Guid enemySpyID)
    {
      LSTEnemySpies.Add(enemySpyID);
    }

  }

  public class SpySkills
  {
    public Guid Id { get; set; }
    public Guid SpyID { get; set; }
    public string Skill { get; set; }
  }
}
