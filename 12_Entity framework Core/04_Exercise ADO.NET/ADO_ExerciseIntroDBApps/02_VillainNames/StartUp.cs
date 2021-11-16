using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _02_VillainNames
{
    class StartUp
    {
        private const string ConnectionString = @"Server=DANE\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {

            //create SQL connection
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            //open SQL connection
            sqlConnection.Open();

            StringBuilder sb = new StringBuilder();

            string getVillianNamesQueryText = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                FROM Villains AS v 
                                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                                GROUP BY v.Id, v.Name 
                                                HAVING COUNT(mv.VillainId) > 3 
                                                ORDER BY COUNT(mv.VillainId)";
            SqlCommand getVillianNameComand = new SqlCommand(getVillianNamesQueryText, sqlConnection);
            using SqlDataReader reader = getVillianNameComand.ExecuteReader();

            while (reader.Read())
            {
                string villainName = reader["Name"]?.ToString();
                string minionsCount = reader["MinionsCount"]?.ToString();
                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            sb.ToString().TrimEnd();

            Console.WriteLine(sb);

        }    
    }
}

