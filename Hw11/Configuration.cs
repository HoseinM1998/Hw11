
public static class Configuration
{
    public static string ConnectionString { get; set; }
    static Configuration()
    {
        ConnectionString = "Server=DESKTOP-78B19T2\\SQLEXPRESS;Initial Catalog=ShopDb;User Id =sa;Password=13771377;TrustServerCertificate=True;";
    }
}

