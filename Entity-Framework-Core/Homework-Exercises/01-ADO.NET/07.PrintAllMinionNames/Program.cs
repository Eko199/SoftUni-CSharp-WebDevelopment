namespace _07.PrintAllMinionNames
{
    using Microsoft.Data.SqlClient;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using var dbConnection =
                new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true");
            await dbConnection.OpenAsync();

            var minionNamesCmd = new SqlCommand(@"SELECT Name FROM Minions", dbConnection);
            SqlDataReader reader = await minionNamesCmd.ExecuteReaderAsync();

            IList<string> minions = new List<string>();

            while (await reader.ReadAsync())
            {
                minions.Add((string) reader["Name"]);
            }

            for (int i = 0; i < minions.Count; i++)
            {
                Console.WriteLine(i % 2 == 0 ? minions[i / 2] : minions[^(i / 2 + 1)]);
            }
        }
    }
}