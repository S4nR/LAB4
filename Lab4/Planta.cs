using System;

namespace Lab4
{
    public class Planta : EntitateEcosistem
    {
        public Planta(string nume, int energie, (int x, int y) pozitie)
            : base(nume, energie, pozitie, 0.8f) { }
        public Planta()
        {

        }

        public override void Actioneaza()
        {
            Energie += 5; // Crește energia prin fotosinteză
        }

        public void Reproduce()
        {
            Console.WriteLine($"{Nume} se reproduce.");
        }
    }
}
