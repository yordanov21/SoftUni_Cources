using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _03_MinionNames
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DANE\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            //create SQL connection
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            //open SQL connection
            sqlConnection.Open();

            int villianAd = int.Parse(Console.ReadLine());
            string result = GetMinionsInfoAboutVillian(sqlConnection, villianAd);

            Console.WriteLine(result);

        }

        private static string GetMinionsInfoAboutVillian(SqlConnection sqlConnection, int villianAd)
        {
            StringBuilder sb = new StringBuilder();

            string getVillianNameQueryText = @"SELECT Name FROM Villains WHERE Id = @villianId";
            using SqlCommand getVillianNameComand = new SqlCommand(getVillianNameQueryText, sqlConnection);
            getVillianNameComand.Parameters.AddWithValue("@villianId", villianAd);

            string villianName = getVillianNameComand
                .ExecuteScalar()?
                .ToString();

            if (villianName == null)
            {
                sb.AppendLine($"No villain with ID {villianAd} exists in the database.");
            }
            else
            {
                sb.AppendLine($"Villiain: {villianName}");

                string getMinionInfoQueryText =
                                         @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                         FROM MinionsVillains AS mv
                                         JOIN Minions As m ON mv.MinionId = m.Id
                                         WHERE mv.VillainId = @villianId
                                         ORDER BY m.Name";

                SqlCommand getMinionsInfoCommand = new SqlCommand(getMinionInfoQueryText, sqlConnection);
                getMinionsInfoCommand.Parameters.AddWithValue("@villianId", villianAd);

                using SqlDataReader reader = getMinionsInfoCommand.ExecuteReader();

                while (reader.Read())
                {
                    string minionRow = reader["RowNum"]?.ToString();
                    string minionName = reader["Name"]?.ToString();
                    string minionAge = reader["Age"]?.ToString();

                    if (minionRow == "" && minionName == "" && minionAge == "")
                    {
                        sb.AppendLine("(no minions)");
                        break;
                    }

                    sb.AppendLine($"{minionRow}. {minionName} {minionAge}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
