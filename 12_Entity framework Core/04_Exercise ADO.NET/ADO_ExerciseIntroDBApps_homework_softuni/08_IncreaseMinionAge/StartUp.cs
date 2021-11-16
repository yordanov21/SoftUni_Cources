using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        string connectionString = @"Server=DANE\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        int[] selectedIds = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
      
        SqlConnection dbSqlConnection = new SqlConnection(connectionString);
        dbSqlConnection.Open();

        List<int> minionIds = new List<int>();
        List<string> minionaNames = new List<string>();
        List<int> minionAges = new List<int>();

        using (dbSqlConnection)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Minions WHERE Id IN ({String.Join(", ", selectedIds)})", dbSqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                if (!reader.HasRows)
                {
                    reader.Close();
                    dbSqlConnection.Close();
                    return;
                }

                while (reader.Read())
                {
                    minionIds.Add((int)reader["Id"]);
                    minionaNames.Add((string)reader["Name"]);
                    minionAges.Add((int)reader["Age"]);
                }
            }

            for (int i = 0; i < minionIds.Count; i++)
            {
                int id = minionIds[i];
                string name = String.Join(" ", minionaNames[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(n => n = char.ToUpper(n.First()) + n.Substring(1).ToLower()).ToArray());
                int age = minionAges[i] + 1;

                command = new SqlCommand("UPDATE Minions SET Name = @name, Age = @age WHERE Id = @Id", dbSqlConnection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }

            command = new SqlCommand($"SELECT * FROM Minions", dbSqlConnection);
            reader = command.ExecuteReader();

            using (reader)
            {
                if (!reader.HasRows)
                {
                    reader.Close();
                    dbSqlConnection.Close();
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine($"{(string)reader["Name"]} {(int)reader["Age"]}");
                }
            }
        }
    }
}
