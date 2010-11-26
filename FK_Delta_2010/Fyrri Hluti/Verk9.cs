using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Delta_2010
{
    class Verk9
    {
        static void Main(string[] args)
        {
            Console.Write("Hversu margar stjörnur eru í þríhyrninginum? ");
            int l = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
