using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SharpBag;
using SharpBag.Math;
using SharpBag.Misc;
using SharpBag.Strings;

namespace Delta2011
{
    public class Delta2011 : ProblemController
    {
        private static void Main(string[] args) { new Delta2011().Run(); }

        public Delta2011() : base("Forritunarkeppnin 2011\nDelta") { }

        #region Problem 17

        [Problem("17", Description = "Stökkvarar.")]
        public void P17()
        {
            Func<int, string> haed = i => this.Read("Hæð " + i + 1);
            var a = haed.Unfold().TakeWhile(i => i != "xxx").ToArray();
            var b = haed.Unfold().TakeWhile(i => i != "xxx").ToArray();
        }

        #endregion Problem 17

        #region Problem 16

        [Problem("16", Description = "Biskup.")]
        public void P16()
        {
            string stads = this.Read("Staðsetning").ToUpper();
            int curX = stads[0] - 'A' + 1;
            int curY = stads.Substring(1).As<int>();
            1.To(8).SelectAll(i => new[] {
                    new { X = curX + i, Y = curY + i },
                    new { X = curX + i, Y = curY - i },
                    new { X = curX - i, Y = curY + i },
                    new { X = curX - i, Y = curY - i }
                }).Where(i => i.X >= 1 && i.Y >= 1 && i.X <= 8 && i.Y <= 8).ForEach(i =>
                {
                    Console.WriteLine(((char)('A' + i.X - 1)).ToString() + i.Y);
                });
        }

        #endregion Problem 16

        #region Problem 15

        [Problem("15", Description = "Diffrun.")]
        public void P15()
        {
            Console.WriteLine((4 * this.Read<int>("a")) + "x^3 + " + (3 * this.Read<int>("b") + "x^2 + " + (2 * this.Read<int>("c")) + "x") + " + " + (this.Read<int>("d")));
        }

        #endregion Problem 15

        #region Problem 14

        [Problem("14", Description = "Orðapör.")]
        public void P14()
        {
            int por = this.Read<int>("Fjöldi para");
            var p = 1.To(por).Select(i => this.Read("Par " + i)).ToArray();
            Console.WriteLine("\nOrðapörin eru:");
            p.ForEach(m => String.Join(" ", m.Split(' ').OrderBy(i => i)).WriteLine());
        }

        #endregion Problem 14

        #region Problem 13

        [Problem("13", Description = "Þríhyrningur.")]
        public void P13()
        {
            int n = this.Read<int>("Hversu margar stjörnur í hlið þríhyrningsins");
            if (n == 0) return;
            if (n > 1) new String('*', n).WriteLine();

            for (int i = n - 3; i >= 0; i--)
            {
                ('*' + new String(' ', i) + '*').WriteLine();
            }

            '*'.WriteLine();
        }

        #endregion Problem 13

        #region Problem 12

        [Problem("12", Description = "Regn 2.")]
        public void P12()
        {
            string[] manudir = new[]
            {
                "janúar",
                "febrúar",
                "mars",
                "apríl",
                "maí",
                "júní",
                "júlí",
                "ágúst",
                "september",
                "október",
                "nóvember",
                "desember"
            };

            var x = 1.To(12).Select(i => new Tuple<int, int>(i, this.Read<int>("Regn í mánuði " + i))).OrderBy(n => n.Item2).ToArray();
            Console.WriteLine();
            x.ForEach(m => Console.WriteLine("Regn í " + manudir[m.Item1 - 1] + " " + m.Item2));
        }

        #endregion Problem 12

        #region Problem 11

        [Problem("11", Description = "Meðalregn.")]
        public void P11()
        {
            string[] manudir = new[]
            {
                "janúar",
                "febrúar",
                "mars",
                "apríl",
                "maí",
                "júní",
                "júlí",
                "ágúst",
                "september",
                "október",
                "nóvember",
                "desember"
            };

            var x = 1.To(12).Select(i => new Tuple<int, int>(i, this.Read<int>("Regn í mánuði " + i))).ToArray();
            Console.WriteLine();
            Console.WriteLine("Meðal úrkoma í mánuði var: " + x.Average(i => i.Item2));
            int min = x.Min(i => i.Item2), max = x.Max(i => i.Item2);

            x.Where(i => i.Item2 == min).ForEach(i => Console.WriteLine("Minnsta úrkoma var í " + (manudir[i.Item1 - 1])));
            x.Where(i => i.Item2 == max).ForEach(i => Console.WriteLine("Mesta úrkoma var í " + (manudir[i.Item1 - 1])));
        }

        #endregion Problem 11

        #region Problem 10

        [Problem("10", Description = "Lottó.")]
        public void P10()
        {
            int[] rettarTolur = this.Read("Réttar tölur").Split(' ').Select(s => s.As<int>()).ToArray();

            Func<Option<int[]>> f = () =>
                {
                    string s = this.Read("Röð sem notandi á");
                    if (s == "-1") return Option.None<int[]>();
                    return Option.Some(s.Split(' ').Select(i => i.As<int>()).ToArray());
                };

            var a = f.Unfold().ToArray();

            Console.WriteLine("Það eru mest " + (a.Max(i => i.Count(n => rettarTolur.Contains(n)))) + " réttar tölur í einni röð.");
        }

        #endregion Problem 10

        #region Problem 9

        [Problem("9", Description = "Stærsti samnefnari.")]
        public void P9()
        {
            int t1 = this.Read<int>("Fyrri tala");
            int t2 = this.Read<int>("Fyrri tala");
            Console.WriteLine("Stærsti samnefnari er " + (BagMath.Gcd(t1, t2)));
        }

        #endregion Problem 9

        #region Problem 8

        [Problem("8", Description = "BMI Tafla.")]
        public void P8()
        {
            Console.SetBufferSize(Console.BufferWidth * 2, Console.BufferHeight);

            for (double thyngd = 55; thyngd <= 125; thyngd += 5)
            {
                if (thyngd == 55) Console.Write("hæð/þyngd\t");
                else Console.Write(thyngd + "\t\t");

                for (double haed = 1.6; haed <= 1.82; haed += 0.02)
                {
                    if (thyngd == 55) Console.Write(haed + "\t");
                    else Console.Write((thyngd / (haed * haed)).ToString("0.00") + "\t");
                }

                Console.WriteLine();
            }

            Console.SetBufferSize(Console.BufferWidth / 2, Console.BufferHeight);
        }

        #endregion Problem 8

        #region Problem 7

        [Problem("7", Description = "BMI Listi.")]
        public void P7()
        {
            double haed = this.ReadDouble("Hæð");

            Console.WriteLine();
            Console.WriteLine("Þyngd\tBMI");
            for (int thyngd = 60; thyngd <= 125; thyngd += 5)
            {
                Console.WriteLine(thyngd + "\t" + (thyngd / (haed * haed)));
            }
        }

        #endregion Problem 7

        #region Problem 6

        [Problem("6", Description = "BMI.")]
        public void P6()
        {
            double haed = this.Read<double>("Hæð");
            double thyngd = this.Read<double>("Þyngd");
            Console.WriteLine("BMI er: " + (thyngd / (haed * haed)));
        }

        #endregion Problem 6

        #region Problem 5

        [Problem("5", Description = "Tákn í texta.")]
        public void P5()
        {
            Console.WriteLine("Í þessum texta eru " + (this.Read("Texti").ToCharArray().Count(c => c != ' ')) + " tákn.");
        }

        #endregion Problem 5

        #region Problem 4

        [Problem("4", Description = "ISBN validator.")]
        public void P4()
        {
            string isbn = this.Read("ISBN númer");
            Console.WriteLine("Þetta er " + (Regex.IsMatch(isbn, "^[0-9]-[0-9]{3}-[0-9]{5}-[0-9]$") ? "" : "ekki ") + "rétt ISBN númer.");
        }

        #endregion Problem 4

        #region Problem 3

        [Problem("3", Description = "Söluverð bókar.")]
        public void P3()
        {
            string heiti = this.Read("Heiti bókar");
            string isbn = this.Read("ISBN númer");
            int kronur = this.Read<int>("Innkaupsverð í krónum");
            double alagning = this.ReadDouble("Álagning í prósentum") / 100 + 1;

            Console.WriteLine();
            Console.WriteLine("Heiti bókar: " + heiti);
            Console.WriteLine("ISBN númer: " + isbn);
            Console.WriteLine("Söluverð: " + (kronur * alagning));
        }

        #endregion Problem 3

        #region Problem 2

        [Problem("2", Description = "Fermetrafjöldi herbergis með villuchecki.")]
        public void P2()
        {
            Func<string, bool> v = s =>
                {
                    bool b = s.As<double>() >= 0;
                    if (!b) Console.WriteLine("Ólöglegur innsláttur.");
                    return b;
                };

            Console.WriteLine("Herbergið er " + (this.Read("Lengd herbegis", validator: v).Replace('.', ',').As<double>() * this.Read("Breidd herbegis", validator: v).Replace('.', ',').As<double>()).ToString("0.0") + " fermetrar");
        }

        #endregion Problem 2

        #region Problem 1

        [Problem("1", Description = "Fermetrafjöldi herbergis.")]
        public void P1()
        {
            Console.WriteLine("Herbergið er " + (this.Read("Lengd herbegis").Replace('.', ',').As<double>() * this.Read("Breidd herbegis").Replace('.', ',').As<double>()).ToString("0.0") + " fermetrar");
        }

        #endregion Problem 1
    }
}