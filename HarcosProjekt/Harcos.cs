using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Harcos
    {
        private string nev;
        private int szint;
        private int tapasztalat;
        private int eletero;
        private int alapEletero;
        private int alapSebzes;


        public string Nev { get => nev; set => nev = value; }
        public int Szint
        {
            get => szint;
            set
            {
                if (this.Tapasztalat>=this.Szintlepeshez)
                {
                    this.tapasztalat -= this.Szintlepeshez;
                    this.Eletero = this.MaxEletero;
                    this.szint = value;
                }
            }
        }
        public int Tapasztalat
        {
            get => tapasztalat;
            set
            {
                if (Szintlepeshez <= this.Tapasztalat)
                {
                    this.Szint++;
                }
                else
                {
                    this.tapasztalat = value;
                }
            }
        }

        public int Eletero
        {
            get => eletero;
            set
            {
                if (this.Eletero <= 0)
                {
                    this.tapasztalat = 0;
                    this.eletero = 0;
                }
                if (this.Eletero > MaxEletero)
                {
                    this.Eletero = MaxEletero;
                }
                else this.eletero = value;
            }
        }
        public int AlapEletero { get => alapEletero; set => alapEletero = value; }
        public int AlapSebzes { get => alapSebzes; set => alapSebzes = value; }
        public int Sebzes { get => alapSebzes + szint; }
        public int MaxEletero { get => alapEletero + szint * 3; }
        public int Szintlepeshez { get => 10 + szint * 5; }
        
        public Harcos(string nev, int statuszSablon)
        {
            this.nev = nev;
            this.szint = 1;
            this.tapasztalat = 0;
            if (statuszSablon == 1)
            {
                this.alapEletero = 15;
                this.alapSebzes = 3;
            }
            else if (statuszSablon == 2)
            {
                this.alapEletero = 12;
                this.alapSebzes = 4;
            }
            else if (statuszSablon == 3)
            {
                this.alapEletero = 8;
                this.alapSebzes = 5;
            }
            this.eletero = MaxEletero;
        }
        public void Megkuzd(Harcos masikHarcos)
        {

            if (this == masikHarcos)
            {
                Console.WriteLine("A két harcos ugyan az a személy.");
            }
            if (this.eletero == 0 || masikHarcos.eletero == 0)
            {
                Console.WriteLine("A harcos életereje 0.");
            }
            else
            {
                
                masikHarcos.Eletero -= this.Sebzes;
                if (masikHarcos.Eletero > 0)
                {
                    this.Eletero -= masikHarcos.Sebzes;
                }
              
                if (masikHarcos.Eletero > 0 && this.Eletero > 0)
                {
                    masikHarcos.Tapasztalat += 5;
                    this.Tapasztalat += 5;
                }
                if (masikHarcos.Eletero > 0 && this.Eletero <= 0)
                {
                    masikHarcos.Tapasztalat += 15;
                }
                else if (masikHarcos.Eletero <= 0 && this.Eletero > 0)
                {
                    this.Tapasztalat += 15;
                }
             
            }
        }
        public void Gyogyul()
        {

            if (this.Eletero <= 0)
            {
                this.Eletero = MaxEletero;
            }
            else
            {
                this.Eletero = 3 + Szint;
            }
        }
        public override string ToString()
        {
            return String.Format("{0} –LVL: {1} –EXP: {2}/{3} –HP: {4}/{5} –DMG: {6}",this.nev, this.szint, this.tapasztalat, Szintlepeshez, this.eletero, MaxEletero, Sebzes);
        }

     

    }
}
