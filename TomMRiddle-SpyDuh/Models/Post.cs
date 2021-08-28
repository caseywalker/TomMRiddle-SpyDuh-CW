using System;
using System.Collections.Generic;

namespace TomMRiddle_SpyDuh.Models
{
  public class Post
  {
    public Guid PostID { get; set; } 
    public Guid SpyID { get; set; }
    public string Services { get; set; }
    public List<string> SpyServices { get; set; }
  
  }
}
