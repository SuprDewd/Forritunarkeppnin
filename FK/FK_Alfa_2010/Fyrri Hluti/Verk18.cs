using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Alfa_2010
{
    class Verk18
    {

        static List<string> ord = new List<string>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("ord.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                SetjaInnOrd(line.Trim().ToLower());
            }
            sr.Close();

            StreamWriter sw = new StreamWriter("ord.txt");
            foreach (string or in ord)
            {
                sw.WriteLine(or);
            }
            sw.Close();
        }

        static void SetjaInnOrd(string o)
        {
            if (ord.Count == 0)
            {
                ord.Add(o);
                return;
            }

            for (int i = 0; i < ord.Count; i++)
            {
                if(Compare(o, ord[i]))
                {
                    BreytaLista(o, i);
                    return;
                }
            }

            ord.Add(o);
        }

        // áabcdéefghíijklmnóoprstúuvxýyzþæö

        static bool Compare(string a, string b)
        {
            if (a == b) return true;

            for (int i = 0; i < (a.Length < b.Length ? a.Length : b.Length); i++)
            {
                if (a[i] == b[i])
                {
                    continue;
                }

                return CompareChar(a[i], b[i]);
            }

            return a.Length < b.Length;
        }

        static bool CompareChar(char a, char b)
        {
            char[] s = new char[] { 'á', 'a', 'b', 'c', 'd', 'é', 'e', 'f', 'g', 'h', 'í', 'i', 'j', 'k', 'l', 'm', 'n', 'ó', 'o', 'p', 'r', 's', 't', 'ú', 'u', 'v', 'x', 'ý', 'y', 'z', 'þ', 'æ', 'ö' };
            int iA = 0;
            int iB = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (a == s[i]) iA = i;

                if (b == s[i]) iB = i;
            }

            return iA <= iB;
        }

        static void BreytaLista(string o, int j)
        {
            List<string> gf = new List<string>();
            List<string> ge = new List<string>();
            for (int i = 0; i < j; i++)
            {
                gf.Add(ord[i]);
            }
            gf.Add(o);
            for (int i = j; i < ord.Count; i++)
            {
                ge.Add(ord[i]);
            }

            ord = new List<string>();
            foreach (string item in gf)
            {
                ord.Add(item);
            }
            foreach (string item in ge)
            {
                ord.Add(item);
            }
        }
    }
}
