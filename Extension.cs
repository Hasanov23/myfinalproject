using System;
namespace BookSystem.TerminallApp
{
    public static partial class Extension
    {

        public static Category AddProduct(Category category, Product product, AppManager manager)
        {
            product.Category = category;

            manager.Product.Add(product);

            return category;


        }

        internal static object ReadInteger(string v)
        {
            throw new NotImplementedException();
        }

        internal static decimal ReadDecimal(string v)
        {
            throw new NotImplementedException();
        }

        internal static string ReadString(string v)
        {
            throw new NotImplementedException();
        }
    }
}
