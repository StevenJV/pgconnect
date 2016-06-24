using System;
using Npgsql;
using System.Configuration;
using System.Collections;

namespace pgconnect
{
  class Program
  {
    static void Main(string[] args) {
      var db = new CommandRunner("dvds");
      //var films = db.Execute<Film>("select * from film");
      //foreach (var film in films)
      //{
      //  Console.WriteLine(film.Title);
      //}
      Console.WriteLine("---");
      var actors = db.Execute<Actor>("select * from actorswithlastname('Pitt')");
      foreach (var actor in actors)
      {
        Console.WriteLine("{0} {1} {2}",actor.actor_id.ToString(),actor.first_name,actor.last_name);
      }
      Console.Read();
    }
  }

  public class Film
  {
    public string Title { get; set; }
  }

  public class Actor
  {
    public int actor_id {get;set;}
    public string first_name { get; set; }
    public string last_name { get; set; }
  }
}
