using System;
using Npgsql;

class Program
{
    static void Main()
    {
        var cs = "Host=mishasdb.postgres.database.azure.com;Username=misha;Password=;Database=azure_app";

        using var con = new NpgsqlConnection(cs);
        con.Open();

        using var cmd = new NpgsqlCommand("SELECT version()", con);
        var version = cmd.ExecuteScalar().ToString();
        Console.WriteLine($"PostgreSQL version: {version}");
    }
}
//"Host=mishasdb.postgres.database.azure.com;Username=misha;Password=;Database=azure_app";