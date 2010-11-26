using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Delta_2010
{
    class Verk5
    {
        static void Main(string[] args)
        {
            Console.Write("Laun á klukkustund? ");
            double laun = Double.Parse(Console.ReadLine());
            Console.Write("Fjöldi klukkustunda sem unnið er? ");
            double klst = Double.Parse(Console.ReadLine());
            laun = laun * klst;
            double skattur = 0;
            if(laun > 30000)
            {
                skattur = (laun - 30000) / 100 * 20;
            }
            Console.WriteLine("Heildarlaun verða þá: " + laun + " krónur");
            Console.WriteLine("Skattur "+skattur+" krónur");
            Console.ReadLine();
        }
    }
}
