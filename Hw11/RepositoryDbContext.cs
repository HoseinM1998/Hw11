using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw11
{
    public class RepositoryDbContext : IProductRepository
    {
        ProductDbContext context = new ProductDbContext();

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = context.Products.Where(p => p.Id == id).First();
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public Product Get(int id)
        {
            return context.Products.Where(p => p.Id == id).First(); 
        }

        public List<Product> GetAll()
        {
            ProductDbContext context = new ProductDbContext();
            return context.Products.ToList();
        }

        public void Update(Product product)
        {
            //var updateProduct = context.Products.Find(product.Id);
            var updateProduct = context.Products.Where(p => p.Id == product.Id).First();
            if (updateProduct != null)
            {
                updateProduct.Name = product.Name;
                updateProduct.CategoryId = product.CategoryId;
                updateProduct.Price = product.Price;
                context.SaveChanges();
            }
        }
    }
}



//AppDbContext context = new AppDbContext();

//var student = new Student() { FirstName = "mohammad", LastName = "javadi", Age = 40 };
//context.Students.Add(student);
//context.SaveChanges();


//var students = context.Students.Where(s => s.FirstName == "Rasool").ToList();

//foreach (var st in students)
//{
//    Console.WriteLine($"{st.Id} - {st.FirstName} {st.LastName} ({st.Age})");
//}


//var student = context.Students.Where(p => p.FirstName == "rasool").First();

//student.Age = 18;

//context.SaveChanges();


//var student = context.Students.Where(p => p.FirstName == "rasool").First();

//context.Remove(student);
//context.SaveChanges();

//Console.WriteLine("Ok");