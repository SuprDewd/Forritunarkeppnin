using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SuprLibrary;

namespace FK_2002
{
    class Verk12
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("keppendur.dat"))
            {
                using (StreamWriter sw = new StreamWriter("TilKeppenda.dat"))
                {
                    int keppz = Int32.Parse(sr.ReadLine());
                    for (int i = 0; i < keppz; i++)
                    {
                        sw.WriteLine("Velkomin(n), " + sr.ReadLine() + ", velkominn í keppnina!");
                    }
                    sw.Close();
                }
                sr.Close();
            }
        }
    }
}
