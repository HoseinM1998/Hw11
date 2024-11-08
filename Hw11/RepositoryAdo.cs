using System.Data.SqlClient;

public class RepositoryAdo
    {


    public void Add(Product product)
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(ProductQueries.Create, connection))
            {
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                command.Parameters.AddWithValue("@Price", product.Price);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
    public List<Product> GetAll()
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(ProductQueries.GetAll, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var products = new List<Product>();
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            CategoryId = (int)reader["CategoryId"],
                            Price = (int)reader["Price"]
                        });
                    }
                    return products;
                }
            }
        }
    }
    public Product Get(int id)
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(ProductQueries.GetById, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            CategoryId = (int)reader["CategoryId"],
                            Price = (int)reader["Price"],
                            //CategoryName = (string)reader["CategoryName"]
                        };
                    }
                }
            }
        }
        return null;
    }

    public void Update(Product product)
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(ProductQueries.Update, connection))
            {
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                command.Parameters.AddWithValue("@Price", product.Price);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
    public void Delete(int id)
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(ProductQueries.Delete, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}

