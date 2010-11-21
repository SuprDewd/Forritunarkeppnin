using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBag;
using SharpBag.Strings;
using SharpBag.Math;
using SharpBag.FK;
using SharpBag.Time;
using SharpBag.FK.MVC;
using SharpBag.Math.Converters;

namespace FKMVCDev
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Delta2005(args).Run();
            new Beta2003(args).Run();
        }
    }

    class Beta2003 : FKController
    {
        public Beta2003(string[] args) : base(new FKModel(), "Beta 2003.\nFyrri Hluti.", args: args) { }
        public override void PreActionExecute() { Console.Clear(); }

        #region 24: Dæmi 24.

        [FKAction("24", Description = "Dæmi 24.")]
        public void Action24()
        {
            string a = this.Model.Read("Aðgerð");
            Stack<double> t = new Stack<double>();

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsNumber(a[i]))
                {
                    t.Push(a[i].ToString().As<int>());
                }
                else
                {
                    double t2 = t.Pop();
                    double t1 = t.Pop();

                    switch (a[i])
                    {
                        case '+': t.Push(t1 + t2); break;
                        case '*': t.Push(t1 * t2); break;
                        case '-': t.Push(t1 - t2); break;
                        case '/': t.Push(t1 / t2); break;
                    }
                }
            }

            this.SimpleView("Útkoma: " + t.Pop(), false);
        }

        #endregion

        #region 23: Dæmi 23.

        [FKAction("23", Description = "Dæmi 23.")]
        public void Action23()
        {
            this.SimpleView(this.SamtalaTveggjaAUndan.Take(this.Model.Read<int>("Tölur")).Select(s => s.ToString()));
        }

        public IEnumerable<int> SamtalaTveggjaAUndan
        {
            get
            {
                int t1 = 1;
                int t2 = 1;

                yield return t1;
                yield return t2;

                while (true)
                {
                    int t3 = t1 + t2;
                    t1 = t2;
                    t2 = t3;
                    yield return t2;
                }
            }
        }

        #endregion

        #region 22: Dæmi 22.

        [FKAction("22", Description = "Dæmi 22.")]
        public void Action22()
        {
            int dagur = this.Model.Read<int>("Dagur");
            int manudur = this.Model.Read<int>("Mánudur");

            var sveinar = new Dictionary<int, string>
            {
                {12, "Stekkjastaur"},
                {13, "Giljagaur"   },
                {14, "Stúfur"      },
                {15, "Þvörusleikir"},
                {16, "Pottaskefill"},
                {17, "Askasleikir" },
                {18, "Hurðaskellir"},
                {19, "Skyrjarmur"  },
                {20, "Bjúgnakrækir"},
                {21, "Gluggagægir" },
                {22, "Gáttaþefur"  },
                {23, "Ketkrókur"   },
                {24, "Kertasníkir" }
            };

            this.BoolView(manudur == 12 && sveinar.ContainsKey(dagur), (sveinar.ContainsKey(dagur) ? sveinar[dagur] : "WTF!") + " kemur til byggða.", "Enginn jólasveinn kemur í dag.");
        }

        [FKView()]
        public void View22()
        {
            Console.WriteLine();

        }

        #endregion

        #region 21: Dæmi 21.

        [FKAction("21", Description = "Dæmi 21.")]
        public void Action21()
        {
            int i = 1;
            var q = (Utils.Generate(() =>
                {
                    string s = this.Model.Read<string>("Lið " + i++);
                    if (s.Trim() == "") return null;

                    return s;
                })).ToArray();

            var lk = (from t1 in q
                      from t2 in q
                      where t1 != t2
                      let b = new string[] { t1, t2 }.OrderBy(s => s)
                      select b.First() + "\t-\t" + b.Last()).Distinct();

            this.SimpleView(lk);
        }

        #endregion

        #region 20: Dæmi 20.

        [FKAction("20", Description = "Dæmi 20.")]
        public void Action20()
        {
            this.SimpleView(DateTime.Now.Year - new Kennitala(this.Model.Read("Kennitala")).Ar + " ára");
        }

        #endregion

        #region 19: Dæmi 19.

        [FKAction("19", Description = "Dæmi 19.")]
        public void Action19()
        {
            this.SimpleView("Öfug: " + this.Model.Read<int>("Tala").Reverse());
        }

        #endregion

        #region 18: Dæmi 18.

        [FKAction("18", Description = "Dæmi 18.")]
        public void Action18()
        {
            this.SimpleView("Þversumma: " + this.Model.Read<int>("Tala").Digits().Sum(i => (int)i));
        }

        #endregion

        #region 17: Dæmi 17.

        [FKAction("17", Description = "Dæmi 17.")]
        public void Action17()
        {
            int kr = this.Model.Read<int>("Krónur");

            var q = (from p5000 in (kr / 5000).To(0)
                     let s5000 = 5000 * p5000
                     from p2000 in ((kr - s5000) / 2000).To(0)
                     let s2000 = 2000 * p2000
                     from p1000 in ((kr - s5000 - s2000) / 1000).To(0)
                     let s1000 = 1000 * p1000
                     from p500 in ((kr - s5000 - s2000 - s1000) / 500).To(0)
                     let s500 = 500 * p500
                     from p100 in ((kr - s5000 - s2000 - s1000 - s500) / 100).To(0)
                     let s100 = 100 * p100
                     from p50 in ((kr - s5000 - s2000 - s1000 - s500 - s100) / 50).To(0)
                     let s50 = 50 * p50
                     from p10 in ((kr - s5000 - s2000 - s1000 - s500 - s100 - s50) / 10).To(0)
                     let s10 = 10 * p10
                     from p5 in ((kr - s5000 - s2000 - s1000 - s500 - s100 - s50 - s10) / 5).To(0)
                     let s5 = 5 * p5
                     from p1 in (kr - s5000 - s2000 - s1000 - s500 - s100 - s50 - s10 - s5).To(0)
                     let s1 = p1
                     where (s5000 + s2000 + s1000 + s500 + s100 + s50 + s10 + s5 + s1) == kr
                     select (p5000 > 0 ? p5000 + "*5000, " : "") +
                            (p2000 > 0 ? p2000 + "*2000, " : "") +
                            (p1000 > 0 ? p1000 + "*1000, " : "") +
                            (p500 > 0 ? p500 + "*500, " : "") +
                            (p100 > 0 ? p100 + "*100, " : "") +
                            (p50 > 0 ? p50 + "*50, " : "") +
                            (p10 > 0 ? p10 + "*10, " : "") +
                            (p5 > 0 ? p5 + "*5, " : "") +
                            (p1 > 0 ? p1 + "*1, " : "")).Select(s => s.Length >= 2 ? s.Substring(0, s.Length - 2) : "");

            this.SimpleView(q.First());
        }

        #endregion

        #region 16: Dæmi 16.

        [FKAction("16", Description = "Dæmi 16.")]
        public void Action16()
        {
            string s = this.Model.Read("Texti").Replace(" ", "").ToLower();
            this.BoolView(s == s.Reverse(), "Textinn er", "ekki", "symmetriskur.");
        }

        #endregion

        #region 15: Dæmi 15.

        [FKAction("15", Description = "Dæmi 15.")]
        public void Action15()
        {
            var q = Utils.Generate(() =>
                {
                    string s = this.Model.Read<string>("Orð");
                    if (s.Trim() == "") return null;
                    else return s;
                }).ToArray();

            char last = default(char);

            bool k = q.All(o =>
                {
                    try
                    {
                        bool b = last == o[0].ToLower() || last == default(char);
                        last = o.Last().ToLower();
                        return b;
                    }
                    catch { return false; }
                });

            this.BoolView(k, "Þetta er keðja.", "Þetta er ekki keðja.");
        }

        #endregion

        #region 14: Dæmi 14.

        [FKAction("14", Description = "Dæmi 14.")]
        public void Action14()
        {
            int i = 1;
            var q = Utils.Generate<int>(() =>
                {
                    try
                    {
                        return Convert.ToInt32(this.Model.Read("Tala " + i++));
                    }
                    catch { return null; }
                });

            this.SimpleView(q.OrderBy(n => n).Select(n => n.ToString()));
        }

        #endregion

        #region 13: Dæmi 13.

        [FKAction("13", Description = "Dæmi 13.")]
        public void Action13()
        {
            int i = 0;
            this.SimpleView("Decimal: " + (this.Model.Read<int>("Binary").Digits().Reverse().Aggregate<short, int>(0, (s, n) => s + (int)(n * Math.Pow(2, i++)))));
        }

        #endregion

        #region 12: Dæmi 12.

        [FKAction("12", Description = "Dæmi 12.")]
        public void Action12()
        {
            this.BoolView(this.Model.Read<string>("Bílnúmer").IsLike("[A-Za-z]{2}-?([A-Za-z0-9])[0-9]{2}"), "Þetta er löglegt númer.", "Þetta er ekki löglegt númer.");
        }

        #endregion

        #region 11: Dæmi 11.

        [FKAction("11", Description = "Dæmi 11.")]
        public void Action11()
        {
            int i = 1;

            var q = Utils.Generate<int>(() =>
                {
                    try
                    {
                        return this.Model.ReadInt("Tala " + i++);
                    }
                    catch { return null; }
                });

            this.SimpleView("Meðaltal: " + q.Average());
        }

        #endregion

        #region 10: Dæmi 10.

        [FKAction("10", Description = "Dæmi 10.")]
        public void Action10()
        {
            string s1 = this.Model.Read<string>("Stafur 1");
            string s2 = this.Model.Read<string>("Stafur 2");

            this.SimpleView(new string[] { s1, s2 }.OrderBy(s => s).First() + " er á undan.");
        }

        #endregion

        #region 9: Dæmi 9.

        [FKAction("9", Description = "Dæmi 9.")]
        public void Action9()
        {
            this.BoolView(this.Model.Read<int>("Tala").IsPrime(), "Þetta er prímtala.", "Þetta er ekki prímtala.");
        }

        #endregion

        #region 8: Dæmi 8.

        [FKAction("8", Description = "Dæmi 8.")]
        public void Action8()
        {
            int tafla = this.Model.Read<int>("Tafla");

            this.SimpleView(1.To(10).Select(i => i + " x " + tafla + " = " + (i * tafla)), true);
        }

        #endregion

        #region 7: Dæmi 7.

        [FKAction("7", Description = "Dæmi 7.")]
        public void Action7()
        {
            int tala = this.Model.Read<int>("Tala");

            this.View7(tala.Factorial());
        }

        [FKView()]
        public void View7(long n)
        {
            Console.WriteLine("Upphrópað: " + n);
        }

        #endregion

        #region 6: Dæmi 6.

        [FKAction("6", Description = "Dæmi 6.")]
        public void Action6()
        {
            int year = this.Model.Read<int>("Ár");

            this.View6(TimeUtils.IsLeapYear(year));
        }

        [FKView()]
        public void View6(bool leapYear)
        {
            Console.WriteLine("Þetta er" + (leapYear ? "" : " ekki") + " hlaupaár.");
        }

        #endregion

        #region 5: Dæmi 5.

        [FKAction("5", Description = "Dæmi 5.", Finished = false)]
        public void Action5()
        {
            double alagningprs = this.Model.Read<double>("Álagningsprósenta");
            double persaflst = this.Model.Read<double>("Persónuafsláttur");
            double laun = this.Model.Read<double>("Laun");

            double stadgrsla = (laun * (100 - alagningprs) / 100) - persaflst;

            this.View5(stadgrsla);
        }

        [FKView()]
        public void View5(double s)
        {
            Console.WriteLine(s);
        }

        #endregion

        #region 4: Dæmi 4.

        [FKAction("4", Description = "Dæmi 4.")]
        public void Action4()
        {
            this.View4(this.Model.Read<int>("Hvað er klukkan", "? "));
        }

        [FKView()]
        public void View4(int k)
        {
            Console.WriteLine(k.IsBetweenOrEqualTo(5, 8) ? "Þú vaknar snemma" :
                k.IsBetweenOrEqualTo(9, 18) ? "Góðan dag" :
                k.IsBetweenOrEqualTo(19, 24) ? "Gott kvöld" :
                k.IsBetweenOrEqualTo(0, 4) ? "Þú átt að vera sofandi" : "Ekki rétt klukkustund");
        }

        #endregion

        #region 3: Dæmi 3.

        [FKAction("3", Description = "Dæmi 3.")]
        public void Action3()
        {
            bool f = this.Model.Read<string>("Viltu breyta úr farenheit í celsius", " (j/n)? ").StartsWithIgnoreCase("j");

            double t = this.Model.Read<double>(f ? "Farenheit" : "Celsius");

            if (f)
            {
                Fahrenheit tmp = t;
                t = (Celsius)tmp;
            }
            else
            {
                Celsius tmp = t;
                t = (Fahrenheit)tmp;
            }

            this.View3(t, f);
        }

        [FKView()]
        public void View3(double t, bool f)
        {
            Console.WriteLine((!f ? "Farenheit" : "Celsius") + ": " + t.ToString("0.00########"));
        }

        #endregion

        #region 2: Dæmi 2.

        [FKAction("2", Description = "Dæmi 2.")]
        public void Action2()
        {
            Fahrenheit f = this.Model.Read<double>("Farenheit"); ;

            this.View2((Celsius)f);
        }

        [FKView()]
        public void View2(Celsius c)
        {
            Console.WriteLine("Celsius: " + ((double)c).ToString("0.00#############"));
        }

        #endregion

        #region 1: Dæmi 1.

        [FKAction("1", Description = "Dæmi 1.")]
        public void Action1()
        {
            decimal t1 = this.Model.Read<decimal>("Tala 1");
            decimal t2 = this.Model.Read<decimal>("Tala 2");

            this.View1(t1 + t2);
        }

        [FKView()]
        public void View1(decimal n)
        {
            Console.WriteLine("Saman: " + n);
        }

        #endregion
    }

    class Delta2005 : FKController
    {
        public Delta2005(string[] args) : base(new FKModel(), "Delta 2005.\nFyrri Hluti.", args: args) { }
        public override void PreActionExecute() { Console.Clear(); }

        #region 26: Dæmi 26.

        [FKAction("26", Description = "Dæmi 26.")]
        public void Action26()
        {
            Dictionary<int, int> runners = new Dictionary<int, int>();

            int time;
            int i = 1;

            do
            {
                time = this.Model.Read<int>("Tími á hlaupara " + i++);

                if (time != 0) runners.Add(i - 1, time);
            }
            while (time != 0);

            this.View26(runners.OrderBy(r => r.Value));
        }

        [FKView()]
        public void View26(IEnumerable<KeyValuePair<int, int>> runners)
        {
            IEnumerable<KeyValuePair<int, int>> r;

            int i = 1;

            while (runners.Any())
            {
                r = runners.Take(4);
                runners = runners.Skip(4);

                Console.WriteLine();
                Console.WriteLine("Riðill " + i++ + ":");
                foreach (var runner in r)
                {
                    Console.WriteLine("Hlaupari " + runner.Key);
                }
            }
        }

        #endregion

        #region 25: Dæmi 25.

        [FKAction("25", Description = "Dæmi 25.", Finished = false)]
        public void Action25()
        {
            double length = this.Model.Read<double>("Lengd flatar (m)");
            double width = this.Model.Read<double>("Breydd flatar (m)");
            double h = this.Model.Read<double>("Stærð hellna (m)");

            this.View25((int)(Math.Ceiling(width / h) * Math.Ceiling(length / h)));
        }

        [FKView()]
        public void View25(int h)
        {
            Console.WriteLine("Hellur: " + h);
        }

        #endregion

        #region 24: Dæmi 24.

        [FKAction("24", Description = "Dæmi 24.")]
        public void Action24()
        {
            int d = this.Model.Read<int>("D");
            int f = this.Model.Read<int>("F");
            int r = this.Model.Read<int>("R");

            var q = from l in new Dictionary<string, int>()
                              {
                                  {"D", d},
                                  {"F", f},
                                  {"R", r}
                              }
                    from i in 1.To(15)
                    let AtkvBak = l.Value / i
                    orderby AtkvBak descending
                    select new { Listi = l.Key, Fulltr = i, AtkvBak };

            var res = from m in q.Take(15)
                      group m by m.Listi into g
                      select new KeyValuePair<string, int>(g.Key, g.Count());

            this.View24(res);
        }

        [FKView()]
        public void View24(IEnumerable<KeyValuePair<string, int>> results)
        {
            Console.WriteLine();

            foreach (var result in results)
            {
                Console.WriteLine(result.Key + ": " + result.Value);
            }
        }

        #endregion

        #region 23: Dæmi 23.

        [FKAction("23", Description = "Dæmi 23.")]
        public void Action23()
        {
            string s = this.Model.Read<string>("Reikningsnúmer");

            this.View23(s.IsLike("[0-9]{4}-[0-9]{2}-[0-9]{6}"));
        }

        [FKView()]
        public void View23(bool ok)
        {
            Console.WriteLine("Innsláttur{0} gildur.", ok ? "" : " ekki");
        }

        #endregion

        #region 22: Dæmi 22.

        [FKAction("22", Description = "Dæmi 22.")]
        public void Action22()
        {
            var ts = this.Model.Read<int>("Sláið inn fjöld sekúntna").Seconds();

            this.View22(ts.Hours, ts.Minutes, ts.Seconds);
        }

        [FKView()]
        public void View22(int h, int m, int s)
        {
            Console.WriteLine("Það eru {0} klst, {1} mín og {2} sek.", h, m, s);
        }

        #endregion

        #region 21: Dæmi 21.

        [FKAction("21", Description = "Dæmi 21.")]
        public void Action21()
        {
            string s = this.Model.Read<string>("Reitur");

            int file = s[0].ToUpper() - 'A' + 1;
            int rank = s[1].ToString().As<int>();

            var q = from f in new int[] { -1, 1, 2, -2 }
                    from r in new int[] { -1, 1, 2, -2 }
                    where Math.Abs(f) != Math.Abs(r)
                    let nf = f + file
                    let nr = r + rank
                    where nf.IsBetweenOrEqualTo(1, 8) && nr.IsBetweenOrEqualTo(1, 8)
                    let str = (nf + 'A' - 1).As<char>().ToString() + nr.ToString()
                    orderby str
                    select str;

            this.View21(q);
        }

        [FKView()]
        public void View21(IEnumerable<string> locs)
        {
            Console.WriteLine();

            foreach (string loc in locs)
            {
                Console.WriteLine(loc);
            }
        }

        #endregion

        #region 20: Dæmi 20.

        [FKAction("20", Description = "Dæmi 20.")]
        public void Action20()
        {
            int l = this.Model.Read<int>("X í hlið");

            this.View20(1.To(l).Sum());
        }

        [FKView()]
        public void View20(int xs)
        {
            Console.WriteLine("X: " + xs);
        }

        #endregion

        #region 19: Dæmi 19.

        [FKAction("19", Description = "Dæmi 19.")]
        public void Action19()
        {
            this.View19(this.Model.Read<int>("X í hlið"));
        }

        [FKView()]
        public void View19(int l)
        {
            Console.WriteLine();
            Console.WriteLine(DrawObjects.Square(l, l, "X", " ", false));
        }

        #endregion

        #region 18: Dæmi 18.

        [FKAction("18", Description = "Dæmi 18.")]
        public void Action18()
        {
            string r = this.Model.Read<string>("Reitur");

            int file = (r[0].ToUpper() - 'A') + 1;
            int rank = Convert.ToInt32(r[1].ToString());

            this.View18(r, r.Length == 2 && file.IsBetweenOrEqualTo(1, 8) && rank.IsBetweenOrEqualTo(1, 8), (file + rank) % 2 != 0);
        }

        [FKView()]
        public void View18(string r, bool til, bool hvitur)
        {
            Console.WriteLine(r + " er " + (!til ? "ekki til" : hvitur ? "hvítur" : "svartur") + ".");
        }

        #endregion

        #region 17: Dæmi 17.

        [FKAction("17", Description = "Dæmi 17.")]
        public void Action17()
        {
            string n = this.Model.Read<string>("Hvað heitir þú", "? ");

            this.View17(n.EndsWithIgnoreCase("son"));
        }

        [FKView()]
        public void View17(bool kk)
        {
            Console.WriteLine("Þú ert " + (kk ? "karl" : "kona") + ".");
        }

        #endregion

        #region 16: Dæmi 16.

        [FKAction("16", Description = "Dæmi 16.")]
        public void Action16()
        {
            int n = this.Model.Read<int>("Sláið inn tölu");

            this.View16(n, !(n != 11 && n.ToString().EndsWith("1")));
        }

        [FKView()]
        public void View16(int n, bool fl)
        {
            Console.WriteLine("Á eftir " + n + " kemur " + (fl ? "fleirtala" : "eintala") + ".");
        }

        #endregion

        #region 15: Dæmi 15.

        [FKAction("15", Description = "Dæmi 15.")]
        public void Action15()
        {
            int sk1 = this.Model.Read<int>("Skammhlið 1");
            int sk2 = this.Model.Read<int>("Skammhlið 2");

            this.View15((int)Math.Sqrt(sk1 * sk1 + sk2 * sk2));
        }

        [FKView()]
        public void View15(int ln)
        {
            Console.WriteLine("Langhlið: " + ln);
        }

        #endregion

        #region 14: Dæmi 14.

        [FKAction("14", Description = "Dæmi 14.")]
        public void Action14()
        {
            Dictionary<int, char> key = new Dictionary<int, char>();

            foreach (int i in 0.To(9))
            {
                char read = this.Model.Read<char>("Fyrir hvað stendur talan " + i, "? ");

                if (read == '$') break;
                else key.Add(i, read);
            }

            Console.WriteLine();

            string code = this.Model.Read<string>("Sláið inn dulkóða");

            this.View14(code.Select(s => s.ToString().As<int>()).Select(c => key.ContainsKey(c) ? key[c] : '?').ToStringPretty(delimiter: ""));
        }

        [FKView()]
        public void View14(string solution)
        {
            Console.WriteLine("Ráðning kóða: " + solution);
        }

        #endregion

        #region 13: Dæmi 13.

        [FKAction("13", Description = "Dæmi 13.")]
        public void Action13()
        {
            double x_gamalt,
                   x_nytt = 1;

            do
            {
                x_gamalt = x_nytt;
                x_nytt = (x_gamalt + 2 / x_gamalt) / 2;
            }
            while (Math.Abs(x_nytt - x_gamalt) >= 0.0001);

            this.View13(x_nytt);
        }

        [FKView()]
        public void View13(double sqroot)
        {
            Console.WriteLine("Kvaðratrót af 2: " + sqroot);
        }

        #endregion

        #region 12: Dæmi 12.

        [FKAction("12", Description = "Dæmi 12.")]
        public void Action12()
        {
            int h = this.Model.Read<int>("Heildarlaun");
            int f = this.Model.Read<int>("Fyrirfram greitt");

            this.View12((int)Math.Max(0, (h * 0.94) - f));
        }

        [FKView()]
        public void View12(int laun)
        {
            Console.WriteLine("Útborguð laun: " + laun);
        }

        #endregion

        #region 11: Dæmi 11.

        [FKAction("11", Description = "Dæmi 11.")]
        public void Action11()
        {
            int n = 0;

            do
            {
                n = this.Model.Read<int>("Sláðu inn tölu á bilinu frá 1 til 100");
            }
            while (n < 1 || n > 100);

            this.View11();
        }

        [FKView()]
        public void View11()
        {
            Console.WriteLine("Takk fyrir, bless.");
        }

        #endregion

        #region 10: Dæmi 10.

        [FKAction("10", Description = "Dæmi 10.")]
        public void Action10()
        {
            int f = this.Model.Read<int>("Fyrsta tala");
            int l = this.Model.Read<int>("Síðasta tala");

            Console.WriteLine();

            this.View9(f.To(l), 3);
        }

        #endregion

        #region 9: Dæmi 9.

        [FKAction("9", Description = "Dæmi 9.")]
        public void Action9()
        {
            this.View9(1.To(10), 3);

        }

        [FKView()]
        public void View9(IEnumerable<int> nums, int pow)
        {
            nums.ForEach(i => Console.WriteLine(i + "\t" + i.Pow(pow)));
        }

        #endregion

        #region 8: Dæmi 8.

        [FKAction("8", Description = "Dæmi 8.")]
        public void Action8()
        {
            int i = 1;
            var nums = Utils.GenerateEndless<int>(() => this.Model.Read<int>("Tala " + i++)).Take(6).ToArray();

            this.View8(nums.Max() - nums.Min());
        }

        [FKView()]
        public void View8(int m)
        {
            Console.WriteLine();

            Console.WriteLine("Mismunur á hæstu og lægstu tölu er " + m + ".");
        }

        #endregion

        #region 7: Dæmi 7.

        [FKAction("7", Description = "Dæmi 7.")]
        public void Action7()
        {
            string w1 = this.Model.Read<string>("Orð 1");
            string w2 = this.Model.Read<string>("Orð 2");

            this.View7(new string[] { w1, w2 }.OrderBy(s => s).First());
        }

        [FKView()]
        public void View7(string w)
        {
            Console.WriteLine();

            Console.WriteLine("Orðið " + w + " er á undan í stafrófsröð.");
        }

        #endregion

        #region 6: Dæmi 6.

        [FKAction("6", Description = "Dæmi 6.")]
        public void Action6()
        {
            string word = this.Model.Read<string>("Orð");

            this.View6(word.Length);
        }

        [FKView()]
        public void View6(int l)
        {
            Console.WriteLine();

            Console.WriteLine("Orðið er " + l + " stafir.");
        }

        #endregion

        #region 5: Dæmi 5.

        [FKAction("5", Description = "Dæmi 5.")]
        public void Action5()
        {
            int i = 1;
            var nums = Utils.GenerateEndless<int>(() => this.Model.Read<int>("Tala " + i++)).Take(6);

            this.View5(nums.Min());
        }

        [FKView()]
        public void View5(int min)
        {
            Console.WriteLine();
            Console.WriteLine("Minnsta talan er " + min);
        }

        #endregion

        #region 4: Dæmi 4.

        [FKAction("4", Description = "Dæmi 4.")]
        public void Action4()
        {
            string name = this.Model.Read<string>("Hvað heitir þú");
            int age = this.Model.Read<int>("Hver aldur þinn " + name);

            this.View4(name, age + (DateTime.Now.Year.ToInfinity().First(y => y % 100 == 0) - DateTime.Now.Year));
        }

        [FKView()]
        public void View4(string name, int nextAge)
        {
            Console.WriteLine();
            Console.WriteLine(name + ", um næstu aldamót verður þú " + nextAge + " árs !");
        }

        #endregion

        #region 3: Dæmi 3.

        [FKAction("3", Description = "Dæmi 3.")]
        public void Action3()
        {
            this.View3((int)Math.Ceiling(this.Model.Read<double>("Kommutala")));
        }

        [FKView()]
        public void View3(int n)
        {
            Console.WriteLine();
            Console.WriteLine(n);
        }

        #endregion

        #region 2: Dæmi 2.

        [FKAction("2", Description = "Dæmi 2.")]
        public void Action2()
        {
            int t1 = this.Model.Read<int>("Tala 1");
            int t2 = this.Model.Read<int>("Tala 2");
            int t3 = this.Model.Read<int>("Tala 3");

            var nums = new int[] { t1, t2, t3 };

            this.View2(nums.Min(), nums.Max());
        }

        [FKView()]
        public void View2(int min, int max)
        {
            Console.WriteLine();

            if (min == max)
            {
                Console.WriteLine("Allar tölur eru eins.");
            }
            else
            {
                Console.Write(min);
                Console.Write(" ");
                Console.WriteLine(max);
            }
        }

        #endregion

        #region 1: Dæmi 1.

        [FKAction("1", Description = "Dæmi 1.")]
        public void Action1()
        {
            int t1 = this.Model.Read<int>("Tala 1");
            int t2 = this.Model.Read<int>("Tala 2");

            this.View1(t2, t1, t1 % t2 == 0);
        }

        [FKView()]
        public void View1(int a, int b, bool g)
        {
            Console.WriteLine();
            Console.WriteLine(a + " gengur" + " ekki".If(!g, "") + " upp í " + b);
        }

        #endregion
    }
}