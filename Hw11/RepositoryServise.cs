using Colors.Net.StringColorExtensions;

public class RepositoryServise : RepsitoryDapper
{
    public string AddProduct(string name, int categoryId, int price)
    {
        try
        {
            if (categoryId > 4)
            {
                return "Error CategoryId |1:Electronics 2:Accessories 3:Peripherals 4:Clothin";
            }
            var product = new Product { Name = name, CategoryId = categoryId, Price = price };
            Add(product);
            return "Add Successfully";
        }
        
        catch (Exception ex)
        {
            return $"Error : {ex.Message}";
        }
    }

    public List<Product> GetAllProducts()
    {
        try
        {
            return GetAll();
        }

        catch (Exception ex)
        {
            return null;
        }
    }

    public Product GetProductById(int id)
    {
        try
        {
            var product = Get(id); 
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Not Found");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error : {ex.Message}");
        }
    }

    public string UpdateProduct(int id, string name, int categoryId, int price)
    {
        try
        {
            if (categoryId > 4)
            {
                return "Error CategoryId |1:Electronics 2:Accessories 3:Peripherals 4:Clothin";
            }
            var product = new Product { Id = id, Name = name, CategoryId = categoryId, Price = price };
            Update(product);
            return "Updated";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public string DeleteProduct(int id)
    {
        try
        {
            Delete(id);
            return "Delete";
        }
        catch (Exception ex) 
        {
            return $"Error : {ex.Message}";
        }
    }


}

