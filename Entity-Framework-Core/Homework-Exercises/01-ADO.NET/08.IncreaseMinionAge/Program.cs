namespace _08.IncreaseMinionAge;

using Microsoft.Data.SqlClient;

internal class Program
{
    static async Task Main(string[] args)
    {
        await using var dbConnection =
            new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true");
        await dbConnection.OpenAsync();

        int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var updateCmd = new SqlCommand(@"UPDATE Minions
                                            SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                          WHERE Id = @Id", dbConnection);

        foreach (int id in ids)
        {
            updateCmd.Parameters.Clear();
            updateCmd.Parameters.AddWithValue("@Id", id);
            await updateCmd.ExecuteNonQueryAsync();
        }

        var minionsCmd = new SqlCommand(@"SELECT Name, Age FROM Minions",  dbConnection);
        SqlDataReader reader = await minionsCmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
        }
    }
}