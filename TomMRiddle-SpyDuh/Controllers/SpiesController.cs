using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
    public IEnumerable<Spy> GetAllSpies()
    {
      return _spyRepo.GetAll();
    }

    [HttpGet("getSpyByID/{spyID}")]
    public void GetSpyByID(Guid spyID)
    {
      _spyRepo.GetByID(spyID);
    }

    [HttpGet("getSpyByName/{name}")]
    public IEnumerable<Spy> GetSpyByName(string name)
    {
      return _spyRepo.GetByName(name);
    }

    [HttpGet("getAllSpiesBySkill/{skill}")]
    public IEnumerable<Spy> GetAllSpiesBySkill(string skill)
    {
      return _spyRepo.GetSpiesBySkill(skill);
    }

    [HttpGet("getAllSpyFriends/{spyID}")]
    public IEnumerable<Spy> GetAllSpyFriends(Guid spyID)
    {
      return _spyRepo.GetSpyFriends(spyID);
    }

    [HttpGet("getAllSpyEnemies/{spyID}")]
    public IEnumerable<Spy> GetAllSpyEnemies(Guid spyID)
    {
      return _spyRepo.GetSpyEnemies(spyID);
    }

    [HttpGet("getSpyAllAvailableSkils/{spyID}")]
    public IEnumerable<string> GetSpyAllAvailableSkils(Guid spyID)
    {
      return _spyRepo.GetSpyAvailableSkils(spyID);
    }

    [HttpGet("getSpyAllSkillsAndServices/{spyID}")]
    public SkillsAndServices GetSpyAllSkillsAndServices(Guid spyID)
    {
      return _spyRepo.GetSkillsAndServices(spyID);
    }

    //Working through getting friends of friends
    [HttpGet("getFriendsOfFriends/{spyID}")]
    public List<Spy> GetFriendsOfFriends(Guid spyID)
    {
      return _spyRepo.FriendsOfFriends(spyID);
    }

    [HttpPost]
    public void AddSpy(Spy newSpy)
    {
      _spyRepo.AddSpy(newSpy);
    }









  }
}
