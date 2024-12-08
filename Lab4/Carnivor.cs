using System;

namespace Lab4
{
    public class Carnivor : Animal
    {
        public Carnivor(string nume, int energie, (int x, int y) pozitie)
            : base(nume, energie, pozitie, 0.9f, 3, TipHrana.Carnivor) { }

        public Carnivor()
        {

        }
        public override void Mananca(EntitateEcosistem prada)
        {
            Console.WriteLine($"{Nume} vaneaza si mananca prada.");
            Energie += 20;
        }

        public override void Actioneaza()
        {
            Deplaseaza();
        }

        public override void Ataca(Animal prada)
        {
            Console.WriteLine($"{Nume} ataca {prada.Nume}.");
        }

        public override void Reproduce()
        {
            Console.WriteLine($"{Nume} se reproduce.");
        }
    }
}
