﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class StartUp
{
    static void Main(string[] args)
    {
        string connectionString = @"Server=DANE\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        SqlConnection dbSqlConnection = new SqlConnection(connectionString);
        dbSqlConnection.Open();

        List<string> minionsInitial = new List<string>();
        List<string> minionsArranged = new List<string>();

        using (dbSqlConnection)
        {
            SqlCommand command = new SqlCommand("SELECT Name FROM Minions", dbSqlConnection);

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
                    minionsInitial.Add((string)reader["Name"]);
                }
            }
        }

        while (minionsInitial.Count > 0)
        {
            minionsArranged.Add(minionsInitial[0]);
            minionsInitial.RemoveAt(0);

            if (minionsInitial.Count > 0)
            {
                minionsArranged.Add(minionsInitial[minionsInitial.Count - 1]);
                minionsInitial.RemoveAt(minionsInitial.Count - 1);
            }
        }

        minionsArranged.ForEach(m => Console.WriteLine(m));
    }
}