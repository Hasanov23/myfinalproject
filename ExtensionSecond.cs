using System;
namespace BookSystem.TerminallApp
{
     static public partial class ExtensionSecond
    {
        public static void SetAuthor(this Product product, Category category, AppManager manager)
        {
            product.Category = category;
        }
    }
}
