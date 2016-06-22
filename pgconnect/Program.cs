using System;
using Npgsql;

namespace pgconnect
{
  class Program
  {
    static void Main(string[] args) {
      var userId = "postgres";
      var password = "none";
      userId = GetUsername(userId);
      password = GetPassword();
      var connectionString = BuildConnectionString(userId, password, "localhost", "dvdrental");
      using (var conn = new NpgsqlConnection(connectionString)) {
        conn.Open();
        var cmd = new NpgsqlCommand("select * from film", conn);
        var rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          Console.WriteLine(rdr["title"]);
        }
        cmd.Dispose();
        conn.Dispose();
      }
      Console.Read();

    }

    public class Film
    {
      public string Title { get; set; }
    }

    private static string BuildConnectionString(string userId, string password, string server, string database) {
      var connectionString = "server=" + server + ";user id =" + userId + ";password=" + password + ";database=" +
                                database;
      return connectionString;
    }

    private static string GetPassword() {
      Console.Write("password: ");
      var password = Console.ReadLine();
      return password;
    }

    private static string GetUsername(string defaultUserId) {
      Console.Write("username (enter=" + defaultUserId + "): ");
      var userIdInput = Console.ReadLine();
      var userId = userIdInput != "" ? userIdInput : defaultUserId;
      return userId;
    }
  }
}
