using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.Config
{
    public class Connection
    {
        public static string ConnectionString=
            @"Server=DANE\SQLEXPRESS;Database=HospitalDb;Integrated Security=True;";
    }
}
