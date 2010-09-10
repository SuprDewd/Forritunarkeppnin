using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk3
    {
        static void Main(string[] args)
        {
                Console.Clear();
                Console.Write("Fermetraverð: ");
                double ferVerd = Convert.ToDouble(Console.ReadLine());
                Console.Write("Fjöldi fermetra: ");
                double ferMetr = Convert.ToDouble(Console.ReadLine());
                double heildarverd = ferVerd * ferMetr;
                Console.WriteLine("Heildarverð verður þá: " + heildarverd);
                Console.ReadLine();
        }
    }
}
