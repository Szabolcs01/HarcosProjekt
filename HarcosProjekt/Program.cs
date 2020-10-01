using System;
using System.Collections.Generic;
using System.IO;

namespace HarcosProjekt
{
    class Program
    {
        static List<Harcos> harcosok;
     
     
        static void Main(string[] args)
        {
            harcosok = new List<Harcos>() { new Harcos("Zoli", 2), new Harcos("Zsombor", 1), new Harcos("Patrik", 3) };

            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine(harcosok[i]);
            }
          
        }
    }
}
