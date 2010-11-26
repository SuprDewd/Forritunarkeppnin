using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Delta_2010
{
    class Verk5B
    {
        static void Main(string[] args)
        {
            Console.Write("Hversu margar stjörnur í hlið þríhyrningsins? ");
            int l = Int32.Parse(Console.ReadLine());
            for (int i = l - 1; i >= 0; i--)
            {
                for (int j = l; j >= 0; j--)
                {
                    if (j > i)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
