using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace FK_Alfa_2010
{
    class Verk13
    {
        static Random rand = new Random();
        static bool upptekid = false;
        static int start;
        static void Main(string[] args)
        {
            start = Environment.TickCount;
            Thread ea = new Thread(new ThreadStart(EinstaklingurA));
            ea.Start();

            while(!ea.IsAlive);

            EinstaklingurB();
            while (ea.IsAlive) ;
            Console.WriteLine("Mínúta liðin.");
            Console.ReadLine();
        }

        static void EinstaklingurA()
        {
            while (upptekid) ;
            upptekid = true;
            Console.WriteLine("A er að leggja inn.");
            Thread.Sleep(rand.Next(0, 6)*1000);
            upptekid = false;
            if(Environment.TickCount - start < 60000)
            {
                EinstaklingurA();
            }
        }

        static void EinstaklingurB()
        {
            while (upptekid) ;
            upptekid = true;
            Console.WriteLine("B er að taka út.");
            Thread.Sleep(rand.Next(0, 6) * 1000);
            upptekid = false;
            if(Environment.TickCount - start < 60000)
            {
                EinstaklingurB();
            }
        }
    }
}
