using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuprLibrary;

namespace FK_Alfa_2010
{
    class Verk15
    {
        static void Main(string[] args)
        {
            Console.Write("Hæð: ");
            int h = Int32.Parse(Console.ReadLine());
            Console.Write("Breydd: ");
            int b = Int32.Parse(Console.ReadLine());

            string[,] field = new string[h, b];

            for (int i = 0; i < h; i++)
            {
                string l = Console.ReadLine().MakeLength(b, '.');
                for (int a = 0; a < b; a++)
                {
                    field[i, a] = l[a].ToString();
                }
            }

            for (int i = 0; i < h; i++)
            {
                for (int a = 0; a < b; a++)
                {
                    if (field[i, a] == "*") continue;

                    field[i, a] = Minesweeper.ManyBombsAround(field, "*", i, a).ToString();
                }
            }

            Console.WriteLine("\n" + field.Output());

            Console.ReadLine();
        }
    }
}
