using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuprLibrary;

namespace FK_2002
{
    class Verk21
    {
        static void Main(string[] args)
        {
            int[] tolurod = new int[] { 1, -3, 4, -2, -1, 6 };

            StærstaRunuSumma runa = new StærstaRunuSumma(tolurod);


            Console.WriteLine("Stærsta summa: "+runa.StærstaSumma);

            foreach (List<int> r in runa.StærstuRunur)
            {
                Console.WriteLine("Stærsta runa: "+String.Join(", ", r.ConvertAll(delegate(int t){ return t.ToString(); }).ToArray()));
            }
            
            Console.ReadLine();
        }
    }
}