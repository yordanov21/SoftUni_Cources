using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace _04_AddMinion
{
    class StartUp
    {
        private const string ConnectionString = @"Server=DANE\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            string[] minionsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] villainInfo = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            string result = AddMinionToDatabase(sqlConnection, minionsInfo, villainInfo);

            Console.WriteLine(result);
        }

        private static string AddMinionToDatabase(SqlConnection sqlConnection, string[] minionsInfo, string[] villainInfo)
        {
            StringBuilder output = new StringBuilder();
            string minionName = minionsInfo[1];
            string minionAge = minionsInfo[2];
            string minionTown = minionsInfo[3];

            string villainName = villainInfo[1];

            string townId = EnsureTownExists(sqlConnection, minionTown, output);
            string villainId = EnsureVillainExists(sqlConnection, villainName, output);

            string insertMinionQueryText = @"INSERT INTO Minions ([Name], Age, TownId) VALUES (@minionName, @minionAge, @townId)";
            using SqlCommand insertMinionCmd = new SqlCommand(insertMinionQueryText, sqlConnection);
            insertMinionCmd.Parameters.AddWithValue("@minionName", minionName);
            insertMinionCmd.Parameters.AddWithValue("@minionAge", minionAge);
            insertMinionCmd.Parameters.AddWithValue("@townId", townId);

            insertMinionCmd.ExecuteNonQuery();
            string getMinionIdQueryText = @"SELECT Id FROM Minions
                                          WHERE [Name]= @minionName";
            using SqlCommand getMinionIdCmd = new SqlCommand(getMinionIdQueryText, sqlConnection);
            getMinionIdCmd.Parameters.AddWithValue("@minionName", minionName);

            string minionId = getMinionIdCmd.ExecuteScalar().ToString();

            string insertIntoMappingQueryText = @"INSERT INTO MinionsVillains(MinionId, VillainId)
                                                VALUES (@minionId, @villianId)";
            using SqlCommand insertIntoMappingCmd = new SqlCommand(insertIntoMappingQueryText, sqlConnection);
            insertIntoMappingCmd.Parameters.AddWithValue("@minionId", minionId);
            insertIntoMappingCmd.Parameters.AddWithValue("@villianId", villainId);

            insertIntoMappingCmd.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            return output.ToString().TrimEnd();
        }

        private static string EnsureVillainExists(SqlConnection sqlConnection, string villainName, StringBuilder output)
        {
            string getVillianIdQueryText = @"SELECT Id FROM Villains
                                          WHERE [Name] = @villianName";
            using SqlCommand getVillainIdCommand = new SqlCommand(getVillianIdQueryText, sqlConnection);
            getVillainIdCommand.Parameters.AddWithValue("@villianName", villainName);

            //ExecuteScalar() to take ony one value
            string villainId = getVillainIdCommand.ExecuteScalar()?.ToString();

            if (villainId == null)
            {
                string getFactorIdQueryText = @"SELECT Id FROM EvilnessFactors
                                                WHERE [Name] = 'Evil'";
                using SqlCommand getFactorIdCmd = new SqlCommand(getFactorIdQueryText, sqlConnection);

                string factorId = getFactorIdCmd.ExecuteScalar()?.ToString();

                string insertVillainQueryText = @"INSERT INTO Villains ([Name], EvilnessFactorId)
                                                VALUES (@villainName, @factorId)";

                using SqlCommand insertVillianCmd = new SqlCommand(insertVillainQueryText, sqlConnection);
                insertVillianCmd.Parameters.AddWithValue("@villainName", villainName);
                insertVillianCmd.Parameters.AddWithValue("@factorId", factorId);

                insertVillianCmd.ExecuteNonQuery();

                villainId = getVillainIdCommand.ExecuteScalar().ToString();
                output.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }

        private static string EnsureTownExists(SqlConnection sqlConnection, string minionTown, StringBuilder output)
        {
            string getTownIdQueryText = @"SELECT Id FROM Towns
                                          WHERE [Name] = @townName";
            using SqlCommand getTownIdCommand = new SqlCommand(getTownIdQueryText, sqlConnection);
            getTownIdCommand.Parameters.AddWithValue("@townName", minionTown);

            //ExecuteScalar() to take ony one value
            string townId = getTownIdCommand.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                string insertTownQueryText = @"INSERT INTO Towns([Name],CountryId)
                                             VALUES (@townName, 1)";
                using SqlCommand insertTownCmd = new SqlCommand(insertTownQueryText, sqlConnection);
                insertTownCmd.Parameters.AddWithValue("@townName", minionTown);

                insertTownCmd.ExecuteNonQuery();
                townId = getTownIdCommand.ExecuteScalar().ToString();

                output.AppendLine($"Town {minionTown} was added to the database.");
            }

            return townId;
        }
    }
}
