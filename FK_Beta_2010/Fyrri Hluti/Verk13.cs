using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FK_Beta_2010
{
    class Verk13
    {
        static void Main(string[] args)
        {
            Regex rx = new Regex("^\\(-?[0-9]+,-?[0-9]+\\)\\(-?[0-9]+,-?[0-9]+\\)\\(-?[0-9]+,-?[0-9]+\\)\\(-?[0-9]+,-?[0-9]+\\)$");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Sláið inn textastreng sem inniheldur hnit hornpunkta:");
                string txt = Console.ReadLine();

                if (rx.IsMatch(txt))
                {
                    Console.WriteLine("Þessi textastrengur fylgir reglum.");
                }
                else
                {
                    Console.WriteLine("Þessi textastrengur fylgir ekki reglum.");
                }
                Console.ReadLine();
            }
        }
    }
}
