using System;
using Npgsql;

namespace PostgreSQLExample
{
    class Program
    {
        static void Main()
        {
            var connectionString = "Host=mishasdb.postgres.database.azure.com;Username=misha;Password=;Database=azure_app";

            try
            {
                // Establishing a connection to the PostgreSQL database
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();

                // Fetching PostgreSQL version
                using (var versionCmd = new NpgsqlCommand("SELECT version()", connection))
                {
                    var version = versionCmd.ExecuteScalar().ToString();
                    Console.WriteLine($"PostgreSQL version: {version}");
                }

                // Retrieving data from a table
                using (var dataCmd = new NpgsqlCommand("SELECT date, username, tweet FROM tweets", connection))
                using (var reader = dataCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime dateValue = reader.GetDateTime(0); // For "date"
                        string usernameValue = reader.GetString(1); // For "username"
                        string tweetValue = reader.GetString(2);    // For "tweet"

                        Console.WriteLine($"Date: {dateValue}, Username: {usernameValue}, Tweet: {tweetValue}");
                    }
                }

            
            }
            catch (NpgsqlException ex)
            {
                // Handle exceptions related to Npgsql
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any general exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}

//"Host=mishasdb.postgres.database.azure.com;Username=misha;Password=;Database=azure_app";
