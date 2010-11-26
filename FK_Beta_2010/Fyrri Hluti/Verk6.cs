using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hversu margar stjörnur í hlið þríhyrningsins? ");
            int m = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < m; j++)
                {
                    if (j >= i)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
