using System;

namespace TomMRiddle_SpyDuh.Models
{
  public class Post
  {
    public Guid PostID { get; set; }
    public Spy SpyID { get; set; }
    public string Services { get; set; }
  }
}
