using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK
{
    class Verk9
    {
        static void Main(string[] args)
        {
            Console.Write("Hversu margar stjörnur í hlið þríhyrningsins? ");
            int m = Int32.Parse(Console.ReadLine());

            for (int i = 1; i <= m; i++)
            {
                Console.WriteLine();
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
            }
            Console.ReadLine();
        }
    }
}
