using System;

namespace BookSystem.TerminallApp
{
    public class Product
    {
        static int counter = 0;
        internal object pageCount;
        internal decimal price;

        public Product()
        {
            this.Id = ++counter;

        }
        public Product(string name)
            : this()
        {
            this.Name = name;
        }

        public Product(string name, decimal price, int year) : this(name)
        {
        }

        public Product(string name, decimal price, int year, Category category)
            : this(name, price, year)
        {
            this.Category = category;
        }

        internal static void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public int Id { get; private set; }

        public string Name { get; set; }
        public string surname { get; set; }

        public decimal Price { get; set; }
        public int Year { get; set;}

        public Category Category{ get; set; }

       
    }
}
