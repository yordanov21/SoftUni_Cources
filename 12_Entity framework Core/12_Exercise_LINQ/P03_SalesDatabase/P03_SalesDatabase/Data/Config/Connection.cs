using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data.Config
{
    public static class Connection
    {
        public static string ConnectionString =
            @"Server=DANE\SQLEXPRESS;Database=SalesDb;Integrated Security=True;";
    }
}
