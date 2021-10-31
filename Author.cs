using System;

namespace BookSystem.TerminallApp
{
     public class Category
    {
       static int counter = 0;
        internal decimal price;
        internal object year;

        public Category()
        {
            this.Id =++counter;
        }

        public Category(string name)
            :this()
        {
            this.Name = name;
        }

        public Category(string name, string model)
            :this(name)
        {

            this.Model = model;
        }

        internal object AddBook(Product book, AppManager manager)
        {
            throw new NotImplementedException();
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Model { get; set; }

        internal void AddProduct(Product product, AppManager manager)
        {
            throw new NotImplementedException();
        }
    }
}
