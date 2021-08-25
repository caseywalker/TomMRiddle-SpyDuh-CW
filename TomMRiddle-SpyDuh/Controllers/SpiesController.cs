using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TomMRiddle_SpyDuh.DataAccessLayer;
using TomMRiddle_SpyDuh.Models;

namespace TomMRiddle_SpyDuh.Controllers
{
  [Route("api/spies")]
  [ApiController]
  public class SpiesController : ControllerBase
  {
    SpyRepository _spyRepo;
    public SpiesController()
    {
      _spyRepo = new SpyRepository();
    }


    [HttpGet]
    public List<Spy> GetAllSpies()
    {
      return _spyRepo.GetAll();
    }

    [HttpGet("")]
    public void GetSpyByID(string spyID)
    {
      _spyRepo.GetSpy(spyID);
    }


    [HttpPost]
    public void AddSpy(Spy newSpy)
    {
      _spyRepo.AddSpy(newSpy);
    }












  }
}
