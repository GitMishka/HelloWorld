using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;

namespace PostgreSQLExample
{
    class Program
    {
        static void Main()
        {
            var connectionString = "Host=mishasdb.postgres.database.azure.com;Username=misha;Password=Manonthemoon123;Database=azure_app";


            // Assuming these as initial maximum lengths based on headers
            int maxDateLength = "Date".Length;
            int maxUsernameLength = "Username".Length;
            int maxTweetLength = "Tweet".Length;

            // Create lists to temporarily hold data since we need two passes
            var dates = new List<DateTime>();
            var usernames = new List<string>();
            var tweets = new List<string>();

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();

                using var dataCmd = new NpgsqlCommand("SELECT date, username, tweet FROM tweets", connection);
                using var reader = dataCmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime dateValue = reader.GetDateTime(0);
                    string usernameValue = reader.GetString(1);
                    string tweetValue = reader.GetString(2);

                    // Check and update max lengths
                    maxDateLength = Math.Max(maxDateLength, dateValue.ToString("M/d/yyyy H:mm").Length);
                    maxUsernameLength = Math.Max(maxUsernameLength, usernameValue.Length);
                    maxTweetLength = Math.Max(maxTweetLength, tweetValue.Length);

                    // Store data temporarily
                    dates.Add(dateValue);
                    usernames.Add(usernameValue);
                    tweets.Add(tweetValue);
                }

                string filePath = @"C:\Users\Misha\source\repos\HelloWorld\output.csv";


                using StreamWriter fileWriter = new StreamWriter(filePath);
                fileWriter.WriteLine($"{"Date".PadRight(maxDateLength)}\t{"Username".PadRight(maxUsernameLength)}\t{"Tweet"}");

                for (int i = 0; i < dates.Count; i++)
                {
                    fileWriter.WriteLine($"{dates[i].ToString("M/d/yyyy H:mm").PadRight(maxDateLength)}\t{usernames[i].PadRight(maxUsernameLength)}\t{tweets[i]}");
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
