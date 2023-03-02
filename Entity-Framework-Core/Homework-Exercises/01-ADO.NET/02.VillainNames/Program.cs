namespace _02.VillainNames;

using Microsoft.Data.SqlClient;

internal class Program
{
    static async Task Main(string[] args)
    {
        await using var dbConnection = new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true");
        await dbConnection.OpenAsync();

        var cmd = new SqlCommand(@"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                             FROM Villains AS v 
                                             JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                         GROUP BY v.Id, v.Name 
                                           HAVING COUNT(mv.VillainId) > 3 
                                         ORDER BY COUNT(mv.VillainId)", dbConnection);

        SqlDataReader reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
        }
    }
}