using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SuprLibrary;

namespace FK_2002
{
    class Verk11
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("PROBLEMX.DAT"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] s = line.Split(" ");
                    Console.WriteLine(Int32.Parse(s[0]) + Int32.Parse(s[1]));
                }
                sr.Close();
            }

            Console.ReadLine();
        }
    }
}
