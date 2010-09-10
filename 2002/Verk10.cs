using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuprLibrary;

namespace FK_2002
{
    class Verk10
    {
        static void Main(string[] args)
        {
            Console.Write("Kennitala: ");
            Kennitala kt = new Kennitala(Console.ReadLine());

            if (kt.ErILagi)
            {
                Console.WriteLine("Þú ert "+kt.Stjornumerki);
            }
            else
            {
                Console.WriteLine("Vitlaus kennitala.");
            }
            Console.ReadLine();
        }
    }
}
