using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK
{
    class Verk4
    {
        static void Main(string[] args)
        {
            Console.Write("Laun á klukkustund: ");
            double laun = Int32.Parse(Console.ReadLine());
            Console.Write("Fjöldi klukkustunda unnið: ");
            double klst = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Þú færð: " + laun * klst);
            Console.ReadLine();
        }
    }
}
