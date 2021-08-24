using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomMRiddle_SpyDuh.DataAccessLayer;

namespace TomMRiddle_SpyDuh.Controllers
{
  [Route("api/posts")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    PostRepository _repo;
    public PostsController()
    {
      _repo = new PostRepository();
    }
  }
}
