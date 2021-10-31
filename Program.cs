using System;

namespace BookSystem.TerminallApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.Title = "Auto Modells System";

            AppManager manager = new AppManager();

            manager.AddProduct("BMW", "E-Series")
            .AddProduct(new Product("E34", 10000, 2011), manager)
            .AddProduct(new Product("E36", 20000, 2012), manager)
            .AddProduct(new Product("E38", 40000, 2013), manager)
            .AddProduct(new Product("E40", 50000, 2014), manager)
            .AddProduct(new Product("E42", 60000, 2015), manager)
            .AddProduct(new Product("E43", 70000, 2016), manager)
            .AddProduct(new Product("E44", 80000, 2017), manager)
            .AddProduct(new Product("E45", 90000, 2018), manager)
            .AddProduct(new Product("E46", 100000, 2019), manager)
            .AddProduct(new Product("E48", 150000, 2020), manager);

        showMenu:

            Console.WriteLine("*************************************************************************************");
            foreach (var item in Enum.GetValues(typeof(Operation)))
            {
                Console.WriteLine($"{((int)item).ToString().PadLeft(2)}.---{item.ToString().PadRight(14)}---!");
            }

            Console.Write("Write your wished operation tool: ");

            string appendedMenuCode =  Console.ReadLine();
            
            if (!(Enum.TryParse(appendedMenuCode, out Operation operationCode) &&
                Enum.IsDefined(typeof(Operation), int.Parse(appendedMenuCode))))
            {

                Console.Clear();
                Console.WriteLine("Choose your wished operation tool from the menu: ");

                goto showMenu;
            }

            switch (operationCode)
            {
                case Operation.ReadAllProducts:
                    PrintAllProducts(manager);
                    goto showMenu;

                case Operation.ReadProduct:
                    Console.Clear();
                    PrintAllProducts(manager);
                    PrintProductById(manager);
                    goto showMenu;

                case Operation.AddProduct:
                    Console.Clear();
                    PrintAllACategories(manager);
                    AddNewProduct(manager);
                    PrintAllProducts(manager);
                    goto showMenu;

                case Operation.EditProduct:
                    Console.Clear();
                    PrintAllProducts(manager);
                    AddEditProduct(manager);
                    goto showMenu;
                case Operation.RemoveProduct:
                    Console.Clear();
                    PrintAllProducts(manager);
                    RemoveProduct(manager);
                    PrintAllProducts(manager);
                    goto showMenu;
                case Operation.SearchProducts:
                    Console.Clear();
                    SearchFromProductList(manager);
                    goto showMenu;





                case Operation.TerminateApp:
                    Console.Clear();
                    Console.WriteLine("Are you sure to leave the system ? (For yes: <Enter>");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Environment.Exit(0);
                    }
                    Console.Clear();
                    goto showMenu;
            
                default:
                    break;


            }

        }

        private static void PrintAllACategories(AppManager manager)
        {
            throw new NotImplementedException();
        }

        private static void PrintProductById(AppManager manager)
        {
        labelReadT:

            Console.Write("Which product should be printed ?");

            if (!int.TryParse(Console.ReadLine(), out int productId))
                goto labelReadT;


            var selectedProduct = manager.Products.Find((b) => b.Id == productId);

            if (selectedProduct == null)
            {
                Console.WriteLine($"The Book with ID {productId} is not existing");
                goto labelReadT;
            }

            Console.WriteLine($"{selectedProduct.Id} {selectedProduct.Name} {selectedProduct.Price} {selectedProduct.Year} {selectedProduct.Category}");

        }

        private static void SearchFromProductList(AppManager manager)
        {
            string searchText = Extension.ReadString("Enter searched word: ");


            var FoundedProducts = manager.Products.FindAll((b) => b.Name.StartsWith(searchText));

            Console.WriteLine($"Founded by {searchText}%");

            foreach (var item in FoundedProducts)
            {
                Console.WriteLine($"{item.Id} {item.Price} {item.Year} {item.Category}");
            }

           
        }

        private static void PrintAllCategories(AppManager manager)
        {
            Console.WriteLine("Printed all Categories");
            foreach (var item in manager.Categories)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Model}");
            }
        }

        private static void PrintAllProducts(AppManager manager)
        {
            Console.WriteLine("Printed all products");
            foreach (var item in manager.Products)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Price} {item.Year} {item.Category}");
            }
        }

        private static void AddNewProduct(AppManager manager)
        {

        labelReadA:

            Console.Write("\n Choose the ID of Book Author:");

            if (!int.TryParse(Console.ReadLine(), out int categoryId))
                goto labelReadA;


            var selected = manager.Categories.Find((a) => a.Id == categoryId);

            if (selected == null)
            {
                Console.WriteLine($"The Category with ID {categoryId} is not existing");
                goto labelReadA;
            }


            Console.Write("Productname: ");

            string productname = Extension.ReadString("ProductName: ");

            int year = (int)Extension.ReadInteger("Product year: ");

            decimal price = Extension.ReadDecimal("Product price: ");

            selected.AddProduct(new Product(productname, price, year), manager);
            Console.Clear();
            Console.WriteLine("Added");

        }

        private static void AddEditProduct(AppManager manager)
        {

        labelEditB:

            Console.Write("\n Choose the ID of Product: ");

            if (!int.TryParse(Console.ReadLine(), out int productId))
                goto labelEditB;


            var selected = manager.Products.Find(a => a.Id == productId);

            if (selected == null)
            {
                Console.WriteLine($"The Category with ID {productId} is not existing");
                goto labelEditB;
            }


            Console.Write("Productname: ");


            selected.pageCount = Extension.ReadInteger("Product year: ");
            selected.price = Extension.ReadDecimal("Product price: ");


            Console.Clear();
            Console.WriteLine("Edited");


        }

        private  static void RemoveProduct(AppManager manager)
        {
         labelEdit:

            Console.Write("\n Choose the ID of Product: ");

            if (!int.TryParse(Console.ReadLine(), out int productId))
                goto labelEdit;


            var selected = manager.Products.Find(a => a.Id == productId);

            if (selected == null)
            {
                Console.WriteLine($"The Categgory with ID {productId} is not existing");
                goto labelEdit;
            }


            manager.Products.Remove(selected);
            Console.Clear();
            Console.WriteLine("Removed");


        }
        private static void AddProduct(Product product, AppManager manager)
        {
            throw new NotImplementedException();
        }
    }
}
