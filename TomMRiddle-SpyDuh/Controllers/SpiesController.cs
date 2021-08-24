using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomMRiddle_SpyDuh.DataAccessLayer;

namespace TomMRiddle_SpyDuh.Controllers
{
  [Route("api/spies")]
  [ApiController]
  public class SpiesController : ControllerBase
  {
    SpyRepository _repo;
    public SpiesController()
    {
      _repo = new SpyRepository();
    }
  }
}
