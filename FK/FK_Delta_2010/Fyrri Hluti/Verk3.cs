using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Delta_2010
{
    class Verk3
    {
        static void Main(string[] args)
        {
            Console.Write("Lengd í kílómetrum? ");
            double km = Double.Parse(Console.ReadLine());
            Console.WriteLine(km+" kílómetrar eru "+(km*1000)+" metrar");
            Console.ReadLine();
        }
    }
}