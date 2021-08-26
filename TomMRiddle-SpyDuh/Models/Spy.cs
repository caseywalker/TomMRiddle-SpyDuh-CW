using System;
using System.Collections.Generic;

namespace TomMRiddle_SpyDuh.Models
{
  public class Spy
  {
    public Guid SpyID { get; set; }
    public string Details { get; set; }
    public string SpyBackground { get; set; }
    public List<string> LSTSkills { get; set; }
    public List<Spy> LSTFriendlySpies { get; set; }
    public List<Spy> LSTEnemySpies { get; set; }
    public List<string> SpyServices { get; set; }
  }


}
