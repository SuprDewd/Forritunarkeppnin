﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Akfa_2010
{
    class Verk3
    {
        static void Main(string[] args)
        {
            Console.Write("Upphafsupphæð: ");
            double upphaf = Double.Parse(Console.ReadLine());
            Console.Write("Árleg viðbót: ");
            double vidbot = Double.Parse(Console.ReadLine());
            Console.Write("Vextir í prósentum: ");
            double vextir = Double.Parse(Console.ReadLine());
            Console.Write("Fjöldi ára: ");
            double ar = Double.Parse(Console.ReadLine());

            double upphaed = upphaf;
            vextir /= 100;

            for (int i = 0; i < ar; i++)
            {
                upphaed += upphaed * vextir;
                if (i != 0)
                {
                    upphaed += vidbot;
                }
            }

            Console.WriteLine("Lokaupphæð er: " + upphaed);
            Console.ReadLine();
        }
    }
}
