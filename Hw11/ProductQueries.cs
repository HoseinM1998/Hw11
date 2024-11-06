public class ProductQueries
    {
    public static string Create = "insert into Products (Name,CategoryId,Price) values (@Name,@CategoryId,@Price);";
    public static string GetById = "SELECT p.Id , p.Name, p.Price , p.CategoryId ,c.Name as categoryName  " +
                                   "FROM [ShopDb].[dbo].[Products] p  " +
                                   "Join Categories c on p.CategoryId = c.Id  " +
                                   "WHERE p.Id = @Id";
    public static string GetAll = "SELECT * FROM Products";
    public static string Delete = "delete Products WHERE Id = @Id";
    public static string Update = "UPDATE Products SET Name=@Name , CategoryId=@CategoryId , Price=@Price WHERE Id = @Id";

}

