
public interface IProductRepository
{
    public void Add(Product product);
    public List<Product> GetAll();
    public Product Get(int id);
    public void Update(Product product);
    public void Delete(int id);
}

