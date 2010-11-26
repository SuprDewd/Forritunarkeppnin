using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Beta_2010
{
    class Verk1
    {
        static void Main(string[] args)
        {
            Console.Write("Nafn: ");
            string nafn = Console.ReadLine();
            string ut = "";
            for (int i = 0; i < nafn.Length; i++)
            {
                ut += nafn[i] + " ";
            }
            Console.WriteLine(ut.Trim());
            Console.ReadLine();
        }
    }
}
