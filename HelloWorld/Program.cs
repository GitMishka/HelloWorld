using System;
using System.IO;
using Npgsql;

namespace PostgreSQLExample
{
    class Program
    {
        static void Main()
        {
            var connectionString = "Host=mishasdb.postgres.database.azure.com;Username=misha;Password=Manonthemoon123;Database=azure_app";

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();

                using var dataCmd = new NpgsqlCommand("SELECT date, username, tweet FROM tweets", connection);
                using var reader = dataCmd.ExecuteReader();

                // Path to the file where data will be saved
                string filePath = @"C:\Users\Misha\source\repos\HelloWorld\output.csv";

                // Using StreamWriter to write data to the file
                using StreamWriter fileWriter = new StreamWriter(filePath);

                // Write the header line
                fileWriter.WriteLine("Date,Username,Tweet");

                while (reader.Read())
                {
                    DateTime dateValue = reader.GetDateTime(0);
                    string usernameValue = reader.GetString(1);
                    string tweetValue = reader.GetString(2).Replace(",", ";"); // To ensure no commas within tweets mess up the format

                    string outputLine = $"{dateValue},{usernameValue},{tweetValue}";
                    fileWriter.WriteLine(outputLine);
                }


                Console.WriteLine("Data has been written to the file successfully!");

            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}

//"Host=mishasdb.postgres.database.azure.com;Username=misha;Password=;Database=azure_app";
