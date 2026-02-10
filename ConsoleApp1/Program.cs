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
                    Console.WriteLine("\n===== HLAVNÍ MENU ÚTULKU =====");
                    Console.WriteLine("1) Přidat nové zvíře");
                    Console.WriteLine("2) Vypsat všechna zvířata");
                    Console.WriteLine("3) Vyhledat zvíře");
                    Console.WriteLine("4) Zaznamenat adopci");
                    Console.WriteLine("5) Zobrazit statistiky");
                    Console.WriteLine("0) Ukončit program");
                    Console.Write("Vaše volba: ");

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
                            Console.WriteLine("Neplatná volba, zkuste to znovu.");
                            break;
                    }
                }
            }

            static void PridaniZvirete(Evidence evidence)
            {
                Console.WriteLine("\n--- ZADÁVÁNÍ NOVÉHO ZVÍŘETE ---");
                Console.Write("Jméno: ");
                string jmeno = Console.ReadLine();
                Console.Write("Druh: ");
                string druh = Console.ReadLine();

                int vek;
                while (true)
                {
                    Console.Write("Věk (číslo): ");
                    if (int.TryParse(Console.ReadLine(), out vek) && vek >= 0) break;
                    Console.WriteLine("Chyba: Zadejte platný věk jako číslo.");
                }

                Console.Write("Pohlaví: ");
                string pohlavi = Console.ReadLine();
                Console.Write("Zdravotní stav: ");
                string stav = Console.ReadLine();
                Console.Write("Poznámka: ");
                string poznamka = Console.ReadLine();

                evidence.PridatZvire(jmeno, druh, vek, pohlavi, stav, poznamka);
            }

            static void Vyhledavani(Evidence evidence)
            {
                Console.WriteLine("\n--- MOŽNOSTI VYHLEDÁVÁNÍ ---");
                Console.WriteLine("1) Hledat podle druhu");
                Console.WriteLine("2) Hledat podle jména");
                Console.WriteLine("3) Hledat podle věku");
                Console.Write("Volba: ");

                string volba = Console.ReadLine();

                if (volba == "1")
                {
                    Console.Write("Zadejte druh zvířete: ");
                    evidence.VyhledatPodleDruhu(Console.ReadLine());
                }
                else if (volba == "2")
                {
                    Console.Write("Zadejte jméno zvířete: ");
                    evidence.VyhledatPodleJmena(Console.ReadLine());
                }
                else if (volba == "3")
                {
                    Console.Write("Zadejte věk pro porovnání: ");
                    if (int.TryParse(Console.ReadLine(), out int vek))
                    {
                        Console.WriteLine("Chcete najít zvířata:");
                        Console.WriteLine("1) Mladší nebo stejně stará");
                        Console.WriteLine("2) Starší nebo stejně stará");
                        Console.Write("Volba: ");

                        string smer = Console.ReadLine();
                        bool mensi = (smer == "1");

                        evidence.VyhledatPodleVeku(vek, mensi);
                    }
                }
            }

            static void OznaceniAdopce(Evidence evidence)
            {
                Console.WriteLine("\n--- ZAZNAMENÁNÍ ADOPCE ---");
                Console.Write("Zadejte unikátní ID zvířete: ");

                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    evidence.OznacitAdopci(id);
                }
                else
                {
                    Console.WriteLine("Chyba: ID musí být celé číslo.");
                }
            }
        }
}
