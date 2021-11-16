﻿using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace _09_IncreaseAgeStoredProcedure
{
    class StartUp
    {
        private const string ConnectionString = @"Server=DANE\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            int minionId = int.Parse(Console.ReadLine());
            string result = IncreaseMinionAgeById(sqlConnection, minionId);
            Console.WriteLine(result);
        }

        private static string IncreaseMinionAgeById(SqlConnection sqlConnection, int minionId)
        {
            //name of stored procedure in SQL
            string procName= "usp_GetOlder";

            using SqlCommand increaseAgeCmd = new SqlCommand(procName, sqlConnection);
            increaseAgeCmd.CommandType = CommandType.StoredProcedure;
            increaseAgeCmd.Parameters.AddWithValue("@minionId", minionId);

            increaseAgeCmd.ExecuteNonQuery();
            string getMinionInfoQuerytext = @"SELECT[Name], Age FROM Minions
                                                WHERE Id = @minionId";

            using SqlCommand getMinionInfoCmd = new SqlCommand(getMinionInfoQuerytext, sqlConnection);
            getMinionInfoCmd.Parameters.AddWithValue("@minionId", minionId);
            using SqlDataReader reader = getMinionInfoCmd.ExecuteReader();
            reader.Read();

            string minionName = reader["Name"].ToString();
            string minionAge = reader["Age"].ToString();
            string result = $"{minionName} – {minionAge} years old";

            return result;
        }
    }
}

