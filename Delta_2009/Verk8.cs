using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk8
    {
        static void Main(string[] args)
        {
            Console.Write("Email: ");
            if (ErEmail(Console.ReadLine()))
            {
                Console.WriteLine("Þetta er netfang.");
            }
            else
            {
                Console.WriteLine("Þetta er ekki netfang.");
            }
            Console.ReadLine();
        }

        static public bool ErEmail(string netfang)
        {
            netfang = netfang.ToLower();

            int att = 0;
            int punktur = 0;
            bool punkturaeftir = false;
            foreach (char stafur in netfang)
            {
                if (stafur == '@')
                {
                    att++;
                }
                if (stafur == '.')
                {
                    punktur++;
                    if (att > 0)
                    {
                        punkturaeftir = true;
                    }
                }
            }

            if (att != 1 || punktur != 1 || !punkturaeftir)
            {
                return false;
            }

            string fremst = netfang.Split('@')[0];
            string midja = netfang.Split('@')[1].Split('.')[0];
            string endi = netfang.Split('@')[1].Split('.')[1];
            if (fremst.Length >= 1)
            {
                foreach (char s in fremst)
                {
                    if ((s >= '1' && s <= '9') || (s >= 'a' && s <= 'z'))
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            if (midja.Length >= 1)
            {
                foreach (char s in midja)
                {
                    if ((s >= '1' && s <= '9') || (s >= 'a' && s <= 'z'))
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            if (endi.Length == 2 || endi.Length == 3)
            {
                foreach (char s in endi)
                {
                    if (s >= 'a' && s <= 'z')
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
