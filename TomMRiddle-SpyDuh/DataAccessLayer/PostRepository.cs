using System;
using System.Collections.Generic;
using System.Linq;
using TomMRiddle_SpyDuh.Models;

namespace TomMRiddle_SpyDuh.DataAccessLayer
{
  public class PostRepository
  {
    static List<Post> _posts = new List<Post>
    {
      new Post
      {
        PostID = Guid.NewGuid(),
        SpyID = new Spy
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
        Services = "This is my first posting, please hire me."
      }
    };
  }
}
