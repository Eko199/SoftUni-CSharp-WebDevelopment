namespace _09.IncreaseAgeStoredProcedure;

using System.Data;
using Microsoft.Data.SqlClient;

internal class Program
{
    static async Task Main(string[] args)
    {
        await using var dbConnection =
            new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true");
        await dbConnection.OpenAsync();

        int id = int.Parse(Console.ReadLine());

        var procedureCmd = new SqlCommand("usp_GetOlder", dbConnection);
        procedureCmd.CommandType = CommandType.StoredProcedure;
        procedureCmd.Parameters.AddWithValue("@id", id);

        await procedureCmd.ExecuteNonQueryAsync();

        var outputCmd = new SqlCommand(@"SELECT Name, Age FROM Minions WHERE Id = @Id", dbConnection);
        outputCmd.Parameters.AddWithValue("@Id", id);

        SqlDataReader reader = await outputCmd.ExecuteReaderAsync();
        await reader.ReadAsync();

        Console.WriteLine($"{reader["Name"]} - {reader["Age"]} years old");
    }
}