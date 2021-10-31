using System;
namespace BookSystem.TerminallApp
{
  static public partial class READEXTENSIONS
    {
        public static string ReadString(string msg)
        {
        l1:
            Console.Write(msg);
            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
                goto l1;
                return value;

        }

        static public int ReadInteger(string msg)
        {
        l1:

            Console.Write(msg);

            if (int.TryParse(Console.ReadLine(), out int value))
                return value;
                goto l1;
            
        }

        static public decimal ReadDecimal (string msg)
        {
        l1:

            Console.Write(msg);
            if (decimal.TryParse(Console.ReadLine(), out decimal value))
                return value;
                goto l1;
            
        }
    }
}
