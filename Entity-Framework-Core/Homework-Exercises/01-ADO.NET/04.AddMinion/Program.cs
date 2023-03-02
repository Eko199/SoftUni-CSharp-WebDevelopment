namespace _04.AddMinion;

using Microsoft.Data.SqlClient;

internal class Program
{
    static async Task Main(string[] args)
    {
        await using var dbConnection =
            new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Database=MinionsDB;Integrated Security=true");
        await dbConnection.OpenAsync();

        SqlTransaction transaction = dbConnection.BeginTransaction();

        string[] minionArgs = Console.ReadLine().Split(": ")[1].Split(' ');
        string villainName = Console.ReadLine().Split(": ")[1];
        string townName = minionArgs[2];

        try
        {
            var townCmd = new SqlCommand(@"SELECT Id FROM Towns WHERE Name = @townName", dbConnection, transaction);
            townCmd.Parameters.AddWithValue("@townName", townName);

            int? townId = (int?)await townCmd.ExecuteScalarAsync();

            if (townId == null)
            {
                var insertTownCmd = new SqlCommand(@"INSERT INTO Towns (Name) VALUES (@townName)", dbConnection,
                    transaction);
                insertTownCmd.Parameters.AddWithValue("@townName", townName);
                await insertTownCmd.ExecuteNonQueryAsync();

                Console.WriteLine($"Town {townName} was added to the database.");
            }

            townId = (int?)await townCmd.ExecuteScalarAsync();

            var insertMinionCmd = new SqlCommand(
                @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)",
                dbConnection, transaction);
            insertMinionCmd.Parameters.AddWithValue("@name", minionArgs[0]);
            insertMinionCmd.Parameters.AddWithValue("@age", int.Parse(minionArgs[1]));
            insertMinionCmd.Parameters.AddWithValue("@townId", townId);

            await insertMinionCmd.ExecuteNonQueryAsync();

            var villainCmd = new SqlCommand(@"SELECT Id FROM Villains WHERE Name = @Name", dbConnection, transaction);
            villainCmd.Parameters.AddWithValue("@Name", villainName);

            int? villainId = (int?)await villainCmd.ExecuteScalarAsync();

            if (villainId == null)
            {
                var insertVillainCmd =
                    new SqlCommand(@"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)",
                        dbConnection, transaction);
                insertVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                await insertVillainCmd.ExecuteNonQueryAsync();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            villainId = (int?)await villainCmd.ExecuteScalarAsync();

            var minionCmd = new SqlCommand(@"SELECT Id FROM Minions WHERE Name = @Name", dbConnection, transaction);
            minionCmd.Parameters.AddWithValue("@Name", minionArgs[0]);

            int minionId = (int)(await minionCmd.ExecuteScalarAsync())!;

            var connectMinionVillainCmd =
                new SqlCommand(@"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)",
                    dbConnection, transaction);
            connectMinionVillainCmd.Parameters.AddWithValue("@minionId", minionId);
            connectMinionVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            await connectMinionVillainCmd.ExecuteNonQueryAsync();
            await transaction.CommitAsync();

            Console.WriteLine($"Successfully added {minionArgs[0]} to be minion of {villainName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await transaction.RollbackAsync();
        }
    }
}