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
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int Eletero { get => eletero; set => eletero = value; }
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
            this.eletero = alapEletero;
        }
        public void Megkuzd(Harcos masikHarcos)
        {
            do
            {
                if (masikHarcos.eletero > 0)
                {
                    this.eletero -= masikHarcos.Sebzes;
                    if (this.eletero > 0)
                    {
                        this.tapasztalat += 5;
                    }
                    else
                    {
                        masikHarcos.tapasztalat += 10;
                    }
                }
                if (this.eletero > 0)
                {
                    masikHarcos.eletero -= this.Sebzes;
                    if (masikHarcos.eletero > 0)
                    {
                        masikHarcos.tapasztalat += 5;
                    }
                    else
                    {
                        this.tapasztalat += 10;
                    }
                }

            } while (masikHarcos.eletero > 0 && this.eletero > 0);
        }
        public void Gyogyul()
        {

            if (this.eletero == 0)
            {
                this.eletero = MaxEletero;
            }
            else
            {
                this.eletero += 3 + this.szint;
            }
        }


        public override string ToString()
        {
            return String.Format("{0}\n – LVL:{1}\n – EXP: {2}/{3}\n – HP:{4}/{5}\n – DMG: {6}",
                this.nev, this.szint, this.tapasztalat, Szintlepeshez, alapEletero, MaxEletero, Sebzes);
           
        }

    }
}
