using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using TomMRiddle_SpyDuh.Models;

namespace TomMRiddle_SpyDuh.DataAccessLayer
{
  public class PostRepository
  {
    readonly string _connectionString;

    public PostRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("SpyduhTom");
    }
    static List<Post> _posts = new List<Post>();

    internal Post GetById(Guid postId)
    {
      return _posts.FirstOrDefault(post => post.PostID == postId);
    }

    internal List<Post> GetAll()
    {
      return _posts;
    }

    internal void AddPost(Post newPost, Guid spyID)
    {
      newPost.PostID = Guid.NewGuid();

      newPost.SpyID = spyID;

      _posts.Add(newPost);
    }
  }
}
