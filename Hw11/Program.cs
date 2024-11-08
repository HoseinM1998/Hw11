using Colors.Net;
using Colors.Net.StringColorExtensions;
using ConsoleTables;

RepositoryServise productService = new RepositoryServise();
ProgressBar _progressBar = new ProgressBar();
int option = -1;

do
{
    try
    {
        Console.Clear();
        ColoredConsole.WriteLine("1.Add New Product\n2.View All Products\n3.Product By Id\n4.Update\n5.Delete\n0.Exit".DarkYellow());
        option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                ColoredConsole.Write("Enter  Name: ".DarkBlue());
                string name = Console.ReadLine();
                ColoredConsole.Write("Enter CategoryId:".DarkBlue()); 
                ColoredConsole.Write("*1:Electronics 2:Accessories 3:Peripherals 4:Clothing* ".DarkGreen()); 
                int categoryId = Convert.ToInt32(Console.ReadLine());
                ColoredConsole.Write("Enter Price: ".DarkBlue());
                int price = Convert.ToInt32(Console.ReadLine());
                string result = productService.AddProduct(name, categoryId, price);
                ColoredConsole.WriteLine(result);
                Console.ReadKey();
                break;
            case 2:


                //var products = productService.GetAll();
                //ConsoleTable
                // .From<Product>(products)
                // .Configure(p => p.NumberAlignment = Alignment.Right)
                // .Write(Format.Alternative);

                var products = productService.GetAllProducts();
                var table = ConsoleTable.From<Product>(products)
                    .Configure(p => p.NumberAlignment = Alignment.Right);
                Console.ForegroundColor = ConsoleColor.Cyan; 
                table.Write(); 
                Console.ResetColor(); 

                //foreach (var product in products)
                //{
                //    ColoredConsole.WriteLine($"Id: {product.Id}, Name: {product.Name}, CategoryId: {product.CategoryId}, Price: {product.Price}".DarkCyan());
                //}
                Console.ReadKey();
                break;

            case 3:
                ColoredConsole.Write("Enter Product Id: ".DarkBlue());
                int id = Convert.ToInt32(Console.ReadLine());
                var productById = productService.GetProductById(id);
                ColoredConsole.WriteLine($"Id:{productById.Id},Name:{productById.Name}, CategoryId:{productById.CategoryId}, CategoryName: ,price:{productById.Price}".DarkMagenta());
                Console.ReadKey();
                break;

            case 4:
                ColoredConsole.Write("Enter Product Id to Update: ".DarkCyan());
                int updateId = Convert.ToInt32(Console.ReadLine());
                var updateProduct = productService.GetProductById(updateId);
                if (updateProduct != null)
                {
                    ColoredConsole.Write("Enter New Name: ".DarkBlue());
                    updateProduct.Name = Console.ReadLine();
                    ColoredConsole.Write("Enter New Category Id: ".DarkBlue());
                    ColoredConsole.Write("*1:Electronics 2:Accessories 3:Peripherals 4:Clothing* ".DarkGreen());
                    updateProduct.CategoryId = Convert.ToInt32(Console.ReadLine());
                    ColoredConsole.Write("Enter New Price: ".DarkBlue());
                    updateProduct.Price = Convert.ToInt32(Console.ReadLine());
                    productService.UpdateProduct(updateId, updateProduct.Name, updateProduct.CategoryId, updateProduct.Price);
                    ColoredConsole.WriteLine("Updated".DarkGreen());
                }
                else
                {
                    ColoredConsole.WriteLine("Not found".DarkRed());
                }
                Console.ReadKey();
                break;

            case 5:
                ColoredConsole.Write("Enter Product Id to Delete: ".DarkBlue());
                int deleteId = Convert.ToInt32(Console.ReadLine());
                var deleteProduct = productService.GetProductById(deleteId);
               
                if (deleteProduct!=null)
                {
                    productService.DeleteProduct(deleteId);
                    ColoredConsole.WriteLine($"Deleted".DarkGreen());
                }
                else
                {
                    ColoredConsole.WriteLine("Not found".DarkRed());

                }
                Console.ReadKey();
                break;

            case 0:
                ColoredConsole.WriteLine("Exiting...".DarkRed());
                Console.ReadKey();
                break;

            default:
                ColoredConsole.WriteLine("Invalid Option Please try again".DarkRed());
                Console.ReadKey();
                break;
        }
    }
    catch (FormatException fe)
    {
        ColoredConsole.WriteLine($"Error Format: {fe.Message}".DarkRed());
        Console.ReadKey();
    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"Error: {ex.Message}".DarkRed());
        Console.ReadKey();
    }
    finally
    {
        _progressBar.DisPlay();
    }
} while (option != 0);

