using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace Lab4
{
    class Program
    {
        static public int UserMenu()
        {
            Console.WriteLine("1. Start ecosistem");
            Console.WriteLine("2. Intampla ceva in ecosistem");
            Console.WriteLine("3. Se misca vietatile");
            Console.WriteLine("4. Afiseaza stare ecosistem");
            Console.WriteLine("5. ");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        } 
        static void Main()
        {
            Console.WriteLine($"Cat este lungimea zonei protejate a vietatilor");
            int Cat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Cat este latimea zonei protejate a vietatilor");
            int PeCat = Convert.ToInt32(Console.ReadLine());
            
            Ecosistem ecosistem = new Ecosistem(Cat,PeCat);
            EntitateEcosistem planta1 = new Planta("Lalea", 10, (0, 0));
            EntitateEcosistem erbivor = new Erbivor("Iepure", 20, (1, 7));
            EntitateEcosistem carnivor = new Carnivor("Lup", 30, (2, 2));
            EntitateEcosistem omnivor = new Omnivor("Urs", 40, (3, 3));
            ecosistem.AdaugaEntitate(planta1);
            ecosistem.AdaugaEntitate(erbivor);
            ecosistem.AdaugaEntitate(carnivor);
            ecosistem.AdaugaEntitate(omnivor);
            while(true)
            {
                switch(UserMenu())
                {
                    case 1:
                        Console.WriteLine("Start ecosistem");
                    break;

                    case 2:
                        Ecosistem.DoSomething(ecosistem);
                    break;

                    case 3:
                        foreach(var it in Ecosistem.entitati)
                        {
                            it.Actioneaza();
                        }
                    break;

                    case 4:
                        EntitateEcosistem.AfiseazaStare();
                    break;
                    
                    case 0:
                        Environment.Exit(0);
                    break; 
                }
            }
        }
    }
}