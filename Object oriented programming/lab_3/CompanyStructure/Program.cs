using System;

namespace CompanyStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Menu().StartDialog();

            Console.Clear();
            Console.WriteLine("Click any button to exit...");
            Console.ReadLine();
        }

    }
}
