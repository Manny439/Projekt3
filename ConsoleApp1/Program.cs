using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Evidence evidence = new Evidence();
            bool konec = false;

            while (!konec)
            {
                Console.WriteLine("\n===== ÚTULEK PRO ZVÍŘATA =====");
                Console.WriteLine("1) Přidat zvíře");
                Console.WriteLine("2) Vypsat všechna zvířata");
                Console.WriteLine("3) Vyhledat / filtrovat");
                Console.WriteLine("4) Označit adopci");
                Console.WriteLine("5) Statistiky");
                Console.WriteLine("0) Konec");
                Console.Write("Volba: ");

                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        PridaniZvirete(evidence);
                        break;

                    case "2":
                        evidence.VypisVse();
                        break;

                    case "3":
                        Vyhledavani(evidence);
                        break;

                    case "4":
                        OznaceniAdopce(evidence);
                        break;

                    case "5":
                        evidence.Statistiky();
                        break;

                    case "0":
                        konec = true;
                        break;

                    default:
                        Console.WriteLine("Neplatná volba.");
                        break;
                }
            }

            Console.WriteLine("Aplikace ukončena.");
        }

        static void PridaniZvirete(Evidence evidence)
        {
            Console.Write("Jméno: ");
            string jmeno = Console.ReadLine();

            Console.Write("Druh (pes/kočka/jiné): ");
            string druh = Console.ReadLine();

            int vek;
            while (true)
            {
                Console.Write("Věk: ");
                if (int.TryParse(Console.ReadLine(), out vek) && vek >= 0)
                    break;

                Console.WriteLine("Zadejte platný věk (0 a více).");
            }

            Console.Write("Pohlaví: ");
            string pohlavi = Console.ReadLine();

            Console.Write("Zdravotní stav: ");
            string stav = Console.ReadLine();

            Console.Write("Poznámka (nepovinné): ");
            string poznamka = Console.ReadLine();

            evidence.PridatZvire(jmeno, druh, vek, pohlavi, stav, poznamka);
        }

        static void Vyhledavani(Evidence evidence)
        {
            Console.WriteLine("\n--- VYHLEDÁVÁNÍ ---");
            Console.WriteLine("1) Podle druhu");
            Console.WriteLine("2) Podle jména");
            Console.WriteLine("3) Podle věku");
            Console.Write("Volba: ");

            string volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    Console.Write("Zadej druh: ");
                    evidence.VyhledatPodleDruhu(Console.ReadLine());
                    break;

                case "2":
                    Console.Write("Zadej jméno: ");
                    evidence.VyhledatPodleJmena(Console.ReadLine());
                    break;

                case "3":
                    Console.Write("Zadej věk: ");
                    int vek = int.Parse(Console.ReadLine());

                    Console.Write("Menší nebo rovno? (a/n): ");
                    bool mensi = Console.ReadLine().ToLower() == "a";

                    evidence.VyhledatPodleVeku(vek, mensi);
                    break;

                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }
        }

        static void OznaceniAdopce(Evidence evidence)
        {
            Console.Write("Zadej ID zvířete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                evidence.OznacitAdopci(id);
            }
            else
            {
                Console.WriteLine("Neplatné ID.");
            }
        }
    }
}
