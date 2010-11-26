using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Akfa_2010
{
    class Verk4
    {
        static void Main(string[] args)
        {
            Console.Write("Texti: ");
            string txt = Console.ReadLine().Replace(".", ". ").Trim().ToLower();

            while (txt.Contains("  "))
            {
                txt = txt.Replace("  ", " ");
            }

            string[] splitt = txt.Split(new string[] { ". " }, StringSplitOptions.None);

            for (int i = 0; i < splitt.Length; i++)
            {
                splitt[i] = splitt[i][0].ToString().ToUpper() + splitt[i].Substring(1);
            }

            txt = String.Join(". ", splitt);
            Console.WriteLine(txt);
            Console.ReadLine();
        }
    }
}
