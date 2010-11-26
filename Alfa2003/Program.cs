using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag;
using SharpBag.Strings;

namespace Alfa2003
{
    class Program
    {
        static void Main(string[] args)
        {
            D14();
        }

        static void D14()
        {
            Console.WriteLine(M(11, 1, 1));
            Console.ReadLine();
            return;

            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(M(n, a, b));
            Console.ReadLine();
        }

        static int M(int n, int a, int b)
        {
            if (n == 1) return a;
            if (n == 2) return b;

            if (n % 2 != 0) return 2 * M(n - 1, a, b) - M(n - 2, a, b);
            else return M(n - 1, a, b) + M(n - 2, a, b);
        }

        static void D13()
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            foreach (char c in 'a'.To('z'))
            {
                chars.Add(c, 0);
            }

            int krona = 0;

            string cmd = Console.ReadLine();
            D13Parse(cmd, ref krona, ref chars, false);
            Console.ReadLine();
        }

        static void D13Parse(string cmd, ref int krona, ref Dictionary<char, int> chars, bool loop)
        {
            do
            {
                for (int i = 0; i < cmd.Length; i++)
                {
                    switch (cmd[i])
                    {
                        case '.': Console.Write(chars.ElementAt(krona).Key); break;
                        case ',': Console.Write(' '); break;
                        case '+': chars[chars.ElementAt(krona).Key]++; break;
                        case '-': chars[chars.ElementAt(krona).Key]--; if (chars.ElementAt(krona).Value < 0) chars[chars.ElementAt(krona).Key] = 0; break;
                        case '<': krona--; if (krona < 0) krona = chars.Count - 1; break;
                        case '>': krona++; if (krona > chars.Count - 1) krona = 0; break;
                        case '[':
                            {
                                StringBuilder nCmd = new StringBuilder();
                                int depth = 1;

                                for (i = i + 1; i < cmd.Length; i++)
                                {
                                    switch (cmd[i])
                                    {
                                        case '[': depth++; break;
                                        case ']': depth--; break;
                                    }

                                    if (depth != 0) nCmd.Append(cmd[i]);
                                    else
                                    {
                                        D13Parse(nCmd.ToString(), ref krona, ref chars, true);
                                        break;
                                    }
                                }
                            } break;
                    }
                }
            } while (loop && chars.ElementAt(krona).Value != 0);
        }
    }
}