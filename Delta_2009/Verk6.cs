using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk6
    {
        static void Main(string[] args)
        {
            Console.Write("Metrar Á Sekúndu: ");
            double ms = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Kílómetrar Á Klukkustund: "+(ms*3.6));
            Console.ReadLine();
        }
    }
}
