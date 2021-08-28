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
    PostRepository _postRepo;
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      _spyRepo = new SpyRepository();
      
      _postRepo = new PostRepository();
      InitializeSpies();
      //InitializePosts();
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
    public void InitializeSpies()
    {
      //Our spies that we start with
      Spy boris = new Spy
      {
        SpyID = new Guid(),
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
        SpyID = new Guid(),
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
          "Inadvertently starting a nuclear standoff"
        },
      };
      Spy alex = new Spy
      {
        SpyID = new Guid(),
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
        SpyID = new Guid(),
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
        SpyID = new Guid(),
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
        SpyID = new Guid(),
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
        SpyID = new Guid(),
        Details = "Spy is here for a good time, not a long time.",
        SpyBackground = "Spy likes to party.",
        LSTSkills = new List<string>
        {
          "Chugging beer"
        },
        SpyServices = new List<string>
        {
          "Inadvertently crashing geopolitical organizations"
        },
      };

      //Adding spies to repo
      _spyRepo.AddSpy(boris);
      _spyRepo.AddSpy(john);
      _spyRepo.AddSpy(alex);
      _spyRepo.AddSpy(paul);
      _spyRepo.AddSpy(nate);
      _spyRepo.AddSpy(ben);
      _spyRepo.AddSpy(james);



      boris.AddSpyToFriendsList(john.SpyID);
      boris.AddSpyToFriendsList(alex.SpyID);
      boris.AddSpyToFriendsList(paul.SpyID);

      john.AddSpyToFriendsList(boris.SpyID);
      john.AddSpyToFriendsList(nate.SpyID);
      john.AddSpyToFriendsList(ben.SpyID);

      alex.AddSpyToFriendsList(james.SpyID);
      alex.AddSpyToFriendsList(boris.SpyID);
      alex.AddSpyToFriendsList(john.SpyID);

      paul.AddSpyToFriendsList(alex.SpyID);


      nate.AddSpyToFriendsList(nate.SpyID);
      nate.AddSpyToFriendsList(james.SpyID);


      ben.AddSpyToFriendsList(john.SpyID);
      ben.AddSpyToFriendsList(paul.SpyID);

      james.AddSpyToFriendsList(boris.SpyID);
      james.AddSpyToFriendsList(john.SpyID);
      james.AddSpyToFriendsList(paul.SpyID);
      james.AddSpyToFriendsList(nate.SpyID);



      //Adding spies to list of friends
      //boris.LSTFriendlySpies = new List<Spy>
      //{
      //  john,
      //  alex,
      //  paul
      //};
      //john.LSTFriendlySpies = new List<Spy>
      //{
      //  boris,
      //  nate,
      //  ben
      //};
      //alex.LSTFriendlySpies = new List<Spy>
      //{
      //  james,
      //  boris,
      //  john
      //};
      //paul.LSTFriendlySpies = new List<Spy>
      //{
      //  alex
      //};
      //nate.LSTFriendlySpies = new List<Spy>
      //{
      //  ben,
      //  james,
      //};
      //ben.LSTFriendlySpies = new List<Spy>
      //{
      //  john,
      //  paul
      //};
      //james.LSTFriendlySpies = new List<Spy>
      //{
      //  boris,
      //  john,
      //  paul,
      //  nate
      //};



      // Adding spies to list of enemies
      //boris.LSTEnemySpies = new List<Spy>
      //{
      //  nate,
      //  ben,
      //  james
      //};

      boris.AddSpyToEnemyList(nate.SpyID);
      boris.AddSpyToEnemyList(ben.SpyID);
      boris.AddSpyToEnemyList(james.SpyID);

      //john.LSTEnemySpies = new List<Spy>
      //{
      //  james,
      //  paul,
      //  alex
      //};

      john.AddSpyToEnemyList(james.SpyID);
      john.AddSpyToEnemyList(paul.SpyID);
      john.AddSpyToEnemyList(alex.SpyID);

      //alex.LSTEnemySpies = new List<Spy>
      //{
      //  paul,
      //  nate,
      //  ben
      //};

      alex.AddSpyToEnemyList(paul.SpyID);
      alex.AddSpyToEnemyList(nate.SpyID);
      alex.AddSpyToEnemyList(ben.SpyID);

      //paul.LSTEnemySpies = new List<Spy>
      //{
      //  nate,
      //  ben,
      //  james,
      //  boris,
      //  john
      //};


      paul.AddSpyToEnemyList(nate.SpyID);
      paul.AddSpyToEnemyList(ben.SpyID);
      paul.AddSpyToEnemyList(james.SpyID);
      paul.AddSpyToEnemyList(boris.SpyID);
      paul.AddSpyToEnemyList(john.SpyID);

      //nate.LSTEnemySpies = new List<Spy>
      //{
      //  boris,
      //  john,
      //  alex,
      //  paul
      //};

      nate.AddSpyToEnemyList(boris.SpyID);
      nate.AddSpyToEnemyList(john.SpyID);
      nate.AddSpyToEnemyList(alex.SpyID);
      nate.AddSpyToEnemyList(paul.SpyID);

      //ben.LSTEnemySpies = new List<Spy>
      //{
      //  alex,
      //  james
      //};

      ben.AddSpyToEnemyList(alex.SpyID);
      ben.AddSpyToEnemyList(james.SpyID);

      //james.LSTEnemySpies = new List<Spy>
      //{
      //  alex,
      //  ben
      //};

      james.AddSpyToEnemyList(alex.SpyID);
      james.AddSpyToEnemyList(ben.SpyID);


      ////Adding spies to repo
      //_spyRepo.AddSpy(boris);
      //_spyRepo.AddSpy(john);
      //_spyRepo.AddSpy(alex);
      //_spyRepo.AddSpy(paul);
      //_spyRepo.AddSpy(nate);
      //_spyRepo.AddSpy(ben);
      //_spyRepo.AddSpy(james);

      InitializePosts(boris, john, alex, paul, nate, ben, james);
    }

    
    //This method is where we will add initial posts to the repository
    public void InitializePosts(Spy boris, Spy john, Spy alex, Spy paul, Spy nate, Spy ben, Spy james)
    {
      //Our posts that we start with
      Post firstPost = new Post
      {
       
        SpyServices = new List<string>
        {
          "Espionage",
          "Political take-over"
        },
        Services = "Will match any price for committing espionage."
      };
      Post secondPost = new Post
      {
        SpyServices = new List<string>
        {
          "Non-Covert Actions",
          "Inadvertently starting a nuclear standoff"
        },
        Services = "You won't find any spy better at creating nuclear standoffs than me."
      };
      Post thirdPost = new Post
      {
        SpyServices = new List<string>
        {
          "Orchestrating internal conflict",
          "Disorganizing internal government agencies"
        },
        Services = "Infiltrating enemy intelligence organizations is my specialty. Call me."
      };
      Post fourthPost = new Post
      {
        SpyServices = new List<string>
        {
          "Digging dirt",
        },
        Services = "I dig dirt. Figuratively, not literally. Hire me. Literally."
      };
      Post fifthPost = new Post
      {
        SpyServices = new List<string>
        {
          "Winter Soldier",
        },
        Services = "Need a bomb planted in the vehicle of someone special? I'm the man for the job."
      };
      Post sixthPost = new Post
      {
        SpyServices = new List<string>
        {
          "Espionage",
          "Dumping tea in the Boston Harbor"
        },
        Services = "Dumping tea in the Boston Harbor is what I do best."
      };
      Post seventhPost = new Post
      {
        SpyServices = new List<string>
        {
          "Inadvertently crashing geopolitical organizations"
        },
        Services = "I can get you those classified documents you want...or your money back."
      };


      //Adding posts to repo
      _postRepo.AddPost(firstPost, boris.SpyID);
      _postRepo.AddPost(secondPost, john.SpyID);
      _postRepo.AddPost(thirdPost, alex.SpyID);
      _postRepo.AddPost(fourthPost, paul.SpyID);
      _postRepo.AddPost(fifthPost, nate.SpyID);
      _postRepo.AddPost(sixthPost, ben.SpyID);
      _postRepo.AddPost(seventhPost, james.SpyID);

    }
  }
}
