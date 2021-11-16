namespace BookShop.Data
{
    internal class Configuration
    {
        internal static string ConnectionString 
            => @"Server=DANE\SQLEXPRESS;Database=BookShop;Integrated Security=True;";
    }
}
