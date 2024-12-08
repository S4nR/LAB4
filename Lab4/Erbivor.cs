using System;

namespace Lab4
{
    public class Erbivor : Animal
    {
        public Erbivor(string nume, int energie, (int x, int y) pozitie)
            : base(nume, energie, pozitie, 0.7f, 2, TipHrana.Erbivor) { }
        
        public Erbivor()
        {

        }
        public override void Mananca(EntitateEcosistem planta)
        {
            Console.WriteLine($"{Nume} mananca planta.");
            Energie += 10;
        }

        public override void Actioneaza()
        {
            Deplaseaza();
        }

        public override void Ataca(Animal prada)
        {
            Console.WriteLine($"{Nume} nu poate ataca (erbivor).");
        }

        public override void Reproduce()
        {
            Console.WriteLine($"{Nume} se reproduce.");
        }
    }
}
