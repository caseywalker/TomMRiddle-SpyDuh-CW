using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomMRiddle_SpyDuh.DataAccessLayer;
using TomMRiddle_SpyDuh.Models;

namespace TomMRiddle_SpyDuh
{
  public class Startup
  {
    //Local copy of the spy repository to add spies on initial load
    SpyRepository _spyRepo;
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      _spyRepo = new SpyRepository();
      initializeSpies();
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "TomMRiddle_SpyDuh", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TomMRiddle_SpyDuh v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
    //This method is where we will add initial spies to the repository
    public void initializeSpies()
    {
      //Our spies that we start with
      Spy boris = new Spy
      {
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
        },
      };
      Spy john = new Spy
      {
        Details = "Spy does bad job",
        SpyBackground = "Spy been doin this a short time",
        LSTSkills = new List<string>
        {
          "Spying",
          "Failing"
        },
        SpyServices = new List<string>
        {
          "Non-Covert Actions",
          "Inadvertly starting a nuclear standoff"
        },
      };
      Spy alex = new Spy
      {
        Details = "You'll never know who's side he's on",
        SpyBackground = "Has been known to play both sides",
        LSTSkills = new List<string>
        {
          "Spying",
          "Double-Agent"
        },
        SpyServices = new List<string>
        {
          "Orchestrating internal conflict",
          "Disorganizing internal government agencies"
        },
      };
      Spy paul = new Spy
      {
        Details = "Spy is clueless",
        SpyBackground = "Spy failed out of spy school",
        LSTSkills = new List<string>
        {
          "None"
        },
        SpyServices = new List<string>
        {
          "Digging dirt",
        },
      };
      Spy nate = new Spy
      {
        Details = "Spy hasn't been seen since 1776.",
        SpyBackground = "The original Spy",
        LSTSkills = new List<string>
        {
          "Spying",
          "Demolition"
        },
        SpyServices = new List<string>
        {
          "Espionage",
          "Dumping tea in the Boston Harbor"
        },
      };
      Spy ben = new Spy
      {
        Details = "Spy doesn't know he's a spy.",
        SpyBackground = "Sleeper agent.",
        LSTSkills = new List<string>
        {
          "Spying",
          "Sleeping"
        },
        SpyServices = new List<string>
        {
          "Winter Soldier",
        },
      };
      Spy james = new Spy
      {
        Details = "Spy is here for a good time, not a long time.",
        SpyBackground = "Spy likes to party.",
        LSTSkills = new List<string>
        {
          "Chugging beer"
        },
        SpyServices = new List<string>
        {
          "Inadvertly crashing geopolitical organizations"
        },
      };

      // Adding spies to list of friends
      boris.LSTFriendlySpies = new List<Spy>
      {
        john,
        alex,
        paul
      };
      john.LSTFriendlySpies = new List<Spy>
      {
        boris,
        nate,
        ben
      };
      alex.LSTFriendlySpies = new List<Spy>
      {
        james,
        boris,
        john
      };
      paul.LSTFriendlySpies = new List<Spy>
      {
        alex
      };
      nate.LSTFriendlySpies = new List<Spy>
      {
        ben,
        james,
      };
      ben.LSTFriendlySpies = new List<Spy>
      {
        john,
        paul
      };
      james.LSTFriendlySpies = new List<Spy>
      {
        boris,
        john,
        paul,
        nate
      };

      // Adding spies to list of enemies
      boris.LSTEnemySpies = new List<Spy>
      {
        nate,
        ben,
        james
      };
      john.LSTEnemySpies = new List<Spy>
      {
        james,
        paul,
        alex
      };
      alex.LSTEnemySpies = new List<Spy>
      {
        paul,
        nate,
        ben
      };
      paul.LSTEnemySpies = new List<Spy>
      {
        nate,
        ben,
        james,
        boris,
        john
      };
      nate.LSTEnemySpies = new List<Spy>
      {
        boris,
        john,
        alex,
        paul
      };
      ben.LSTEnemySpies = new List<Spy>
      {
        alex,
        james
      };
      james.LSTEnemySpies = new List<Spy>
      {
        alex,
        ben
      };


      //Adding spies to repo
      _spyRepo.AddSpy(boris);
      _spyRepo.AddSpy(john);
      _spyRepo.AddSpy(alex);
      _spyRepo.AddSpy(paul);
      _spyRepo.AddSpy(nate);
      _spyRepo.AddSpy(ben);
      _spyRepo.AddSpy(james);
    }

  }
}
