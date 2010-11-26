using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk16
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Frábær 3 fyrir 2 tilboð: ");
            StreamReader sr = new StreamReader("vorur.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                string[] split = line.Split(' ');
                //Console.WriteLine(String.Join(" ", split));
                if (split[0] == "*")
                {
                    int verd = Int32.Parse(split[split.Length-1]);
                    string nafn = "";
                    for (int i = 1; i < split.Length-1; i++)
                    {
                        nafn += split[i] + " ";
                    }
                    nafn = nafn.Trim();
                    Console.WriteLine(nafn+" - "+(verd*2)+" krónur");
                }
            }
            sr.Close();
            Console.ReadLine();
        }
    }
}
