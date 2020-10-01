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
       
        static void Main(string[] args)
        {
            harcosok = new List<Harcos>() { new Harcos("Zoli", 2), new Harcos("Zsombor", 1), new Harcos("Patrik", 3) };
            beolvas("harcosok.csv");
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine(harcosok[i]);
            }
            
        }
    }
}
