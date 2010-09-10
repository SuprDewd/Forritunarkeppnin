using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk4
    {
        static void Main(string[] args)
        {
            Console.Write("Fullt Nafn: ");
            string nafn = Console.ReadLine();

            Console.WriteLine("Halló "+nafn.Split(' ')[0]);
            Console.ReadLine();
        }
    }
}
