using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Transactions;
#pragma warning disable IDE0051
#pragma warning disable CS8618
#pragma warning disable IDE0035
#pragma warning disable CS0162
#pragma warning disable CS8603
namespace Lab4
{
    public class Ecosistem
    {
        static public List<EntitateEcosistem> entitati = new List<EntitateEcosistem>();
        public static int [,] Rezervatie {get; private set;}
        public static Dictionary<string,(int, int)> AmplasamentVietate = new Dictionary<string,(int, int)>();
        public static Dictionary<string, int> IdAnimal = new Dictionary<string, int>();
        public static int NumarAnimale = 0;
        public static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        public Ecosistem(int Cat, int PeCat)
        {
            Rezervatie = new int[Cat, PeCat];
        }

        public void AdaugaEntitate(EntitateEcosistem entitate)
        {
            entitati.Add(entitate);
            AmplasamentVietate.Add(entitate.Nume,entitate.Pozitie);
            ++NumarAnimale;
            IdAnimal.Add(entitate.Nume,NumarAnimale);
            Rezervatie[entitate.Pozitie.x,entitate.Pozitie.y] = NumarAnimale;
        }

       /* public void SimuleazaPas()
        {
            foreach (var entitate in entitati)
            {
                entitate.Actioneaza();
            }
        }*/
        static public void DoSomething(Ecosistem ecosistem)
        {
            Random rand1 = new Random();
            int val = rand1.Next(1,6);
            switch(val)
            {
                case 1:
                    //Move
                    Console.WriteLine("Animals move");
                    foreach(var it in Ecosistem.entitati)
                    {
                        it.Actioneaza();
                    }
                break;

                case 2:
                    //Reproduce random
                    Console.WriteLine("Animals do babies");
                    Random rand2 = new Random();
                    EntitateEcosistem NewSpecies = GetRandomSpecies();
                    int size = rand2.Next(3,7);
                    string name = string.Empty;
                    for(int i = 0; i < size; i++)
                    {
                        name += Alphabet[rand2.Next(0,Alphabet.Length - 1)];
                    }
                    NewSpecies.Nume = name;
                    NewSpecies.Energie = rand2.Next(1,100);
                    // while()
                    NewSpecies.Pozitie = (rand2.Next(0,Rezervatie.GetLength(0)),rand2.Next(0,Rezervatie.GetLength(1)));
                    NewSpecies.RataSupravietuire = rand2.Next(50,100);
                    ecosistem.AdaugaEntitate(NewSpecies);

                break;
                    
                case 3:
                    //Grow
                    Console.WriteLine("Animals grow");
                    Random ran = new Random();
                    foreach(var it in Ecosistem.entitati)
                    {
                        it.Energie += ran.Next(1,50);
                    }
                break;

                case 4:
                   //Fight
                Console.WriteLine("Animals fight");
                   Random rnd = new Random();
                   BattleAnimals(Ecosistem.entitati[rnd.Next(0,entitati.Count)],Ecosistem.entitati[rnd.Next(0,entitati.Count)]);
                break;

                default:
                    Console.WriteLine("Nice");
                break;

            }
        }
        static public void BattleAnimals(EntitateEcosistem ent1,EntitateEcosistem ent2)
        {
            while(true)
            {
                if(GetAttackResult(ent1,ent2) == "Game Over")
                {
                    Console.WriteLine($"Warrior {ent2.Nume} is dead");
                    break;
                }
                if(GetAttackResult(ent2,ent1) == "Game Over")
                {
                    Console.WriteLine($"Warrior {ent1.Nume} is dead");
                    break;
                }
            }
        }
        public static string GetAttackResult(EntitateEcosistem ent1,EntitateEcosistem ent2)
        {
            Random r = new Random();
            double warriorAAttkAmt = r.Next(1,10);
            double warriorBBlkAmt = r.Next(1,10);
            
            double dmg2warriorB = warriorAAttkAmt - warriorBBlkAmt;

            if(dmg2warriorB > 0)
            {
                ent2.Energie = ent2.Energie - (int)dmg2warriorB;
            }
            else
                dmg2warriorB = 0;
            
            Console.WriteLine($"{ent1.Nume} Attacks {ent2.Nume} and Deals {dmg2warriorB} damage");
            Console.WriteLine($"{ent1.Nume} Has {ent2.Energie} Health {dmg2warriorB} damage");

            if(ent2.Energie <= 0)
            {
                Console.WriteLine($"{ent2.Nume} Has died and {ent1.Nume} is victorious");
                AmplasamentVietate.Remove(ent2.Nume);
                Rezervatie[ent2.Pozitie.x,ent2.Pozitie.y] = 0;
                IdAnimal.Remove(ent2.Nume);
                return "Game Over";
            }
                return "Fight Again";
        }
        public static EntitateEcosistem GetRandomSpecies()
        {
            Random RandVal = new Random();
            int species = RandVal.Next(1,5);
            switch(species)
            {
                case 1:
                    Console.WriteLine("Plant created");
                    return new Planta();
                break;

                case 2:
                    Console.WriteLine("Carnivor created");
                    return new Carnivor();
                break;

                case 3:
                    Console.WriteLine("Erbivor created");
                    return new Erbivor();
                break;

                case 4:
                    Console.WriteLine("Omnivor created");
                    return new Omnivor();
                break;
            }
            return null;
        }

        /*
            public void AfiseazaInfo(Ecosistem ecosistem)
            {
                foreach (var entitate in entitati)
                {
                    ecosistem.AfiseazaInfo(ecosistem);
                }
            }
        */
    }
}
