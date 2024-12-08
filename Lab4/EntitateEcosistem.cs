using System;
#pragma warning disable CS8618
namespace Lab4
{
    public abstract class EntitateEcosistem
    {
        public string Nume { get;  set; }
        public int Energie { get;  set; }
        public (int x, int y) Pozitie { get;set; }
        public float RataSupravietuire { get;  set; }

        public EntitateEcosistem(string nume, int energie, (int x, int y) pozitie, float rataSupravietuire)
        {
            Nume = nume;
            Energie = energie;
            Pozitie = pozitie;
            RataSupravietuire = rataSupravietuire;
        }
        public EntitateEcosistem()
        {

        }

        public abstract void Actioneaza();

        public static void AfiseazaStare()
        {
            for (int i = 0; i < Ecosistem.Rezervatie.GetLength(0); i++)
            {
                for (int j = 0; j < Ecosistem.Rezervatie.GetLength(1); j++)
                {
                    if(Ecosistem.Rezervatie[i, j] == 0)
                    {
                        Console.Write("{.} ");
                    }
                    else
                    {
                        if(Ecosistem.IdAnimal.ContainsValue(Ecosistem.Rezervatie[i, j]))
                        {
                            var key = Ecosistem.IdAnimal
                                .FirstOrDefault(x => x.Value == Ecosistem.Rezervatie[i, j]).Key;
                            Console.Write($"{key}");
                        }
                    }
                }
                Console.WriteLine();
            }
            // Console.WriteLine($"{Nume} (Energie: {Energie}, Pozitie: ({Pozitie.x}, {Pozitie.y}))");
        }
    }
}

/*
    var PozitieCurenta = (i,j);
    var vietate = Ecosistem.AmplasamentVietate
        .FirstOrDefault(v => v.Value == PozitieCurenta);
    if(vietate.Equals(default(KeyValuePair<string, (int, int)>)))
*/