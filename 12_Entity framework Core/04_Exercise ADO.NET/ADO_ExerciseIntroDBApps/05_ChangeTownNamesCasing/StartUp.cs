using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
class StartUp
{
    static void Main(string[] args)
    {
        string countryName = Console.ReadLine();

        string connectionString = @"Server=DANE\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        SqlConnection dbSqlConnection = new SqlConnection(connectionString);
        dbSqlConnection.Open();

        using (dbSqlConnection)
        {
            int? countryId = (int?)new SqlCommand($"SELECT Id FROM Countries WHERE Name = '{countryName}'", dbSqlConnection).ExecuteScalar();

            if (countryId == null)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                int townsCount = (int)new SqlCommand($"SELECT COUNT(*) FROM Towns WHERE CountryId = {countryId}", dbSqlConnection).ExecuteScalar();

                SqlDataReader reader = new SqlCommand($"SELECT * FROM Towns WHERE CountryId = {countryId}", dbSqlConnection).ExecuteReader();

                var townNamesAffected = new List<String>();
                var townIdsAffected = new List<int>();

                using (reader)
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No town names were affected.");
                        reader.Close();
                        dbSqlConnection.Close();
                        return;
                    }

                    while (reader.Read())
                    {

                        string townName = (string)reader["Name"];
                        int townId = (int)reader["Id"];

                        townNamesAffected.Add(townName.ToUpper());
                        townIdsAffected.Add(townId);
                    }
                }

                for (int i = 0; i < townIdsAffected.Count; i++)
                {
                    new SqlCommand($"UPDATE Towns SET Name = '{townNamesAffected[i].ToUpper()}' WHERE Id = {townIdsAffected[i]}", dbSqlConnection).ExecuteNonQuery();
                }

                Console.WriteLine($"{townsCount} town names were affected.");
                Console.WriteLine($"[{String.Join(", ", townNamesAffected)}]");
            }
        }
    }
}