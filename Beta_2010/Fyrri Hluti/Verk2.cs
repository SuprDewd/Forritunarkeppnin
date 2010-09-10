using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk2
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("tolur.txt");
            string skra = sr.ReadToEnd();
            skra = skra.Replace(",", " ").Replace("\r\n", " ").Replace("\n", " ").Trim();
            while (skra.Contains("  "))
            {
                skra = skra.Replace("  ", " ");
            }
            string[] tolur = skra.Split(' ');
            for (int i = 0; i < tolur.Length; i++)
            {
                Console.Write((i+1)+":"+tolur[i]+"\t");
                int tala = Int32.Parse(tolur[i]);
                for (int j = 0; j < tala; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
