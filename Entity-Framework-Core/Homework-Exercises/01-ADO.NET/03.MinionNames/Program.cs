namespace _03.MinionNames;

using Microsoft.Data.SqlClient;

internal class Program
{
    static async Task Main(string[] args)
    {
        int villainId = int.Parse(Console.ReadLine());

        await using var dbConnection =
            new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true");
        await dbConnection.OpenAsync();

        var villainCommand = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @Id", dbConnection);
        villainCommand.Parameters.AddWithValue("@Id", villainId);

        string? villainName = (string?)await villainCommand.ExecuteScalarAsync();

        if (villainName == null)
        {
            Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            return;
        }

        Console.WriteLine($"Villain: {villainName}");

        var minionsCommand = new SqlCommand(@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                                     m.Name, 
                                                     m.Age
                                                FROM MinionsVillains AS mv
                                                JOIN Minions As m ON mv.MinionId = m.Id
                                               WHERE mv.VillainId = @Id
                                            ORDER BY m.Name", dbConnection);
        minionsCommand.Parameters.AddWithValue("@Id", villainId);

        SqlDataReader reader = await minionsCommand.ExecuteReaderAsync();

        if (!reader.HasRows)
        {
            Console.WriteLine("(no minions)");
            return;
        }

        while (await reader.ReadAsync())
        {
            Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
        }
    }
}