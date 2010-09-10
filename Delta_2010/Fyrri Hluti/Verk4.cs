using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Delta_2010
{
    class Verk4
    {
        static void Main(string[] args)
        {
            Console.Write("Laun á klukkustund? ");
            double laun = Int32.Parse(Console.ReadLine());
            Console.Write("Fjöldi klukkustunda sem unnið er? ");
            double klst = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Heildarlaun verða þá: " + laun * klst);
            Console.ReadLine();
        }
    }
}
