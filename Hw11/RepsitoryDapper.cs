using System.Data.SqlClient;
using System.Data;
using Dapper;

public class RepsitoryDapper
    {
    public void Add(Product product)
    {
        using (IDbConnection db = new SqlConnection(Configuration.ConnectionString))
        {
            db.Execute(ProductQueries.Create, new { product.Name, product.CategoryId, product.Price });
        }
    }
    public List<Product> GetAll()
    {
        using (IDbConnection db = new SqlConnection(Configuration.ConnectionString))
        {
            return db.Query<Product>(ProductQueries.GetAll).ToList();
        }
    }
    public Product Get(int id)
    {
        using (IDbConnection db = new SqlConnection(Configuration.ConnectionString))
        {
            return db.QueryFirstOrDefault<Product>(ProductQueries.GetById, new { Id = id });
        }
    }

    public void Update(Product product)
    {
        using (IDbConnection db = new SqlConnection(Configuration.ConnectionString))
        {
            db.Execute(ProductQueries.Update, new { Id = product.Id, Name = product.Name, CategoryId = product.CategoryId, Price = product.Price });
        }
    }
    public void Delete(int id)
    {
        using (IDbConnection db = new SqlConnection(Configuration.ConnectionString))
        {
            db.Execute(ProductQueries.Delete, new { Id = id });
        }
    }

}

