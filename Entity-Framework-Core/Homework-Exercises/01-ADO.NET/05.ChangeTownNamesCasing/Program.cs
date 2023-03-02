namespace _05.ChangeTownNamesCasing;

using Microsoft.Data.SqlClient;

internal class Program
{
    static async Task Main(string[] args)
    {
        await using var dbConnection =
            new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true");
        await dbConnection.OpenAsync();

        string country = Console.ReadLine();

        var updateTownsCmd = new SqlCommand(@"UPDATE Towns
                                                 SET Name = UPPER(Name)
                                               WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)",
            dbConnection);
        updateTownsCmd.Parameters.AddWithValue("@countryName", country);

        int count = await updateTownsCmd.ExecuteNonQueryAsync();

        if (count == 0)
        {
            Console.WriteLine("No town names were affected.");
            return;
        }

        Console.WriteLine($"{count} town names were affected.");

        var getTownsCmd = new SqlCommand(@"SELECT t.Name 
                                             FROM Towns as t
                                             JOIN Countries AS c ON c.Id = t.CountryCode
                                            WHERE c.Name = @countryName", dbConnection);
        getTownsCmd.Parameters.AddWithValue("@countryName", country);

        SqlDataReader reader = await getTownsCmd.ExecuteReaderAsync();
        ICollection<string> towns = new List<string>(count);

        while (await reader.ReadAsync())
        {
            towns.Add((string)reader["Name"]);
        }

        Console.WriteLine($"[{string.Join(", ", towns)}]");
    }
}