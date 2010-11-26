using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Delta_2010
{
    class Verk11
    {
        static void Main(string[] args)
        {
            Console.Write("Hversu margar gráður? ");
            int grad = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Það eru " + (grad / 360) + " hringir og " + (grad % 360) + " gráður.");
            Console.ReadLine();
        }
    }
}
