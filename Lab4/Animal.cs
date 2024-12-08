#pragma warning disable CS8604 
namespace Lab4
{
    public enum TipHrana { Erbivor, Carnivor, Omnivor }

    public abstract class Animal : EntitateEcosistem, IInteractiune
    {
        public int Viteza { get; protected set; }
        public TipHrana TipHrana { get; protected set; }

        public Animal(string nume, int energie, (int x, int y) pozitie, float rataSupravietuire, int viteza, TipHrana tipHrana)
            : base(nume, energie, pozitie, rataSupravietuire)
        {
            Viteza = viteza;
            TipHrana = tipHrana;
        }
        public Animal()
        {
            
        }

        public void Deplaseaza()
        {
            Random rnd1 = new Random();
            string signs = "+-";
            Ecosistem.Rezervatie[Pozitie.x, Pozitie.y] = 0;
            char SignX = signs[rnd1.Next(0,signs.Length)];
            char SignY = signs[rnd1.Next(0,signs.Length)];
            
            int XChange = (SignX == '+') ? rnd1.Next(0,Viteza + 1) : -rnd1.Next(0,Viteza + 1);
            int YChange = (SignY == '+') ? rnd1.Next(0,Viteza + 1) : -rnd1.Next(0,Viteza + 1);
            
            Pozitie = (Pozitie.x + XChange, Pozitie.y + YChange);
            if(Pozitie.x > Ecosistem.Rezervatie.GetLength(0))
            {
                Pozitie = (Ecosistem.Rezervatie.GetLength(0) - 1,Pozitie.y);
            }
            if(Pozitie.y > Ecosistem.Rezervatie.GetLength(1))
            {
                Pozitie = (Pozitie.y,Ecosistem.Rezervatie.GetLength(1) - 1);
            }
            if(Pozitie.y < 0)
            {
                Pozitie = (Pozitie.x,0);
            }
            if(Pozitie.x < 0)
            {
                Pozitie = (0,Pozitie.y);
            }
            Ecosistem.AmplasamentVietate[Nume] = Pozitie;
            // Ecosistem.IdAnimal[Nume] = Pozitie;
            Ecosistem.Rezervatie[Pozitie.x, Pozitie.y] = Ecosistem.IdAnimal[Nume];
        }

        public abstract void Mananca(EntitateEcosistem entitate);
        public abstract void Ataca(Animal prada);
        public abstract void Reproduce();
    }
}
