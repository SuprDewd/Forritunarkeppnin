using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk7
    {
        static void Main(string[] args)
        {
            Console.Write("Byrjunarhraði í m/s: ");
            double byrjun = Convert.ToDouble(Console.ReadLine());
            Console.Write("Lokahraði í m/s: ");
            double loka = Convert.ToDouble(Console.ReadLine());
            Console.Write("Stikun: ");
            double stikun = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("m/s\tkm/klst");
            for (double i = byrjun; i <= loka; i += stikun)
            {
                Console.WriteLine(i+"\t"+(i*3.6));
            }

            Console.ReadLine();
        }
    }
}
