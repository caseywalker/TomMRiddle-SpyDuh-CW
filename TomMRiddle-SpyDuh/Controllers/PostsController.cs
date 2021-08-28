using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TomMRiddle_SpyDuh.DataAccessLayer;
using TomMRiddle_SpyDuh.Models;

namespace TomMRiddle_SpyDuh.Controllers
{
  [Route("api/posts")]    //exposes function at this endpoint
  [ApiController]         //api controller - returns json/xml
  public class PostsController : ControllerBase
  {
    PostRepository _postRepo;
    public PostsController()
    {
      _postRepo = new PostRepository();
    }

    [HttpGet]
    public List<Post> GetAllPosts()
    {
      return _postRepo.GetAll();
    }

    //Asking for someone to give a parameter of a post -> newPost
    //It is an instance of the class Post called newPost
    [HttpPost] 
    public void AddPost(Post newPost)
    {
      _postRepo.AddPost(newPost);
    }
  }
}
