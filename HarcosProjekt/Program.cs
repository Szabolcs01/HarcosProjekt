using System;
using System.Collections.Generic;
using System.IO;

namespace HarcosProjekt
{
    class Program
    {
        static List<Harcos> harcosok;
        static void beolvas(string file)
        {
            StreamReader sr = new StreamReader("harcosok.csv");
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                harcosok.Add(new Harcos(sor[0], Convert.ToInt32(sor[1])));
            }
            sr.Close();
        }
        public static Harcos felhasznalo()
        {
            string felhasznaloNev;
            int statusz;
            Console.WriteLine("Adja meg a karaktere felhasználó nevét!");
            felhasznaloNev = Console.ReadLine();
            Console.WriteLine("Adja meg a karaktere státusz sablonját!");
            Console.WriteLine("1.\t HP:18/18 - DMG: 4\n" +
                "2.\t HP:15/15 - DMG: 5\n" +
                "3.\t HP:11/11 - DMG: 6\n");
            do
            {
                statusz = Convert.ToInt32(Console.ReadLine());
                if (statusz > 3 || statusz < 1)
                {
                    Console.WriteLine("HIBÁS adat!");
                }
            } while (!(statusz > 0 && statusz < 4));
            return new Harcos(felhasznaloNev,statusz);
        }
        public static void harcoskokkiir()
        {
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine((i + 1) + ".\t" + harcosok[i]);
            }
        }

      public static  string betu = " ";
        public static void menu()
        {
                string betu = " ";


                Console.WriteLine("Mit szeretnél tenni? ");
            Console.WriteLine("a.) Megküzdeni egy harcossal" +
                "\n\tb.) Gyógyulni" +
                "\n\tc.) Kilépni");
            do
            {
                betu =Console.ReadLine();
            

                if (!(betu.Equals("a") || betu.Equals("b") || betu.Equals("c")))
                {
                    Console.WriteLine("Nincs ilyen menüpont, adja meg újra!");
                }
   
        } while (!(betu=="a" || betu =="b" || betu == "c"));
        }

        static void Main(string[] args)
        {
            harcosok = new List<Harcos>() { new Harcos("Zoli", 2), new Harcos("Zsombor", 3), new Harcos("Patrik", 1) };
            beolvas("harcosok.csv");

          
            for (int i = 0; i < harcosok.Count; i++)
            {
                                Console.WriteLine(+(i+1)+""+harcosok[i]);
              
            }
       
            harcosok.Add(felhasznalo());
            Console.WriteLine(harcosok[harcosok.Count - 1]);
            harcoskokkiir();
            do
            {
                menu();
            } while (betu=="c");
            
            Console.ReadKey();
        }
    }
}
