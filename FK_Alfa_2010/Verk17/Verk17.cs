using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SuprLibrary;

namespace FK_Alfa_2010
{
    class Verk17
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("tidni.txt");
            string txt = sr.ReadToEnd();
            sr.Close();
            Dictionary<char, int> takn = new Dictionary<char, int>();

            for (int i = 0; i < txt.Length; i++)
            {
                char s = Char.Parse(txt[i].ToString().ToLower());
                if (Char.IsLetterOrDigit(s) || new string[] { "á", "í", "ú", "ý", "ó", "é", "þ", "ð", "æ", "ö" }.Contains(s.ToString().ToLower()))
                {
                    takn.AddIfNotContainsKey(s, 1, 1);
                }
            }

            var sortedDict = (from entry in takn orderby entry.Value descending select entry);

            foreach (KeyValuePair<char, int> t in sortedDict)
            {
                Console.WriteLine(t.Key + " " + t.Value);
            }
            Console.ReadLine();
        }
    }
}
