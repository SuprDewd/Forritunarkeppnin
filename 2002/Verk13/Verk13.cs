using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SuprLibrary;

namespace FK_2002
{
    class Verk13
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("texti.txt"))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    i++;
                    Console.WriteLine("Lína "+i+" inniheldur "+line.Words().Count()+" orð.");
                }
                sr.Close();
            }
            Console.ReadLine();
        }
    }
}
