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
      var films = db.Execute<Film>("select * from film");
      foreach (var film in films)
      {
        Console.WriteLine(film.Title);
      }
      Console.Read();
    }
  }

  public class Film
  {
    public string Title { get; set; }
  }
}
