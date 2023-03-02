namespace _06.RemoveVillain
{
    using Microsoft.Data.SqlClient;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using var dbConnection =
                new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true");
            await dbConnection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());
            SqlTransaction transaction = dbConnection.BeginTransaction();

            try
            {

                var villainCmd = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @villainId", dbConnection, transaction);
                villainCmd.Parameters.AddWithValue("@villainId", villainId);

                string? villainName = (string?) await villainCmd.ExecuteScalarAsync();

                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                var deleteConnectionsToMinionsCmd = new SqlCommand(@"DELETE FROM MinionsVillains WHERE VillainId = @villainId", dbConnection, transaction);
                deleteConnectionsToMinionsCmd.Parameters.AddWithValue("@villainId", villainId);

                int releasedMinions = await deleteConnectionsToMinionsCmd.ExecuteNonQueryAsync();

                var deleteVillainCmd = new SqlCommand(@"DELETE FROM Villains WHERE Id = @villainId", dbConnection,
                    transaction);
                deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                await deleteVillainCmd.ExecuteNonQueryAsync();
                await transaction.CommitAsync();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await transaction.RollbackAsync();
            }
        }
    }
}