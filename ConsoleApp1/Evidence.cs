using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Evidence
    {
        private List<Zvire> seznamZvirat = new List<Zvire>();

        public void PridatZvire(string jmeno, string druh, int vek, string pohlavi, string stav, string poznamka)
        {
            Zvire nove = new Zvire(jmeno, druh, vek, pohlavi, DateTime.Now, stav, poznamka);
            seznamZvirat.Add(nove);
            Console.WriteLine($"Zvíře {jmeno} bylo úspěšně uloženo.");
        }

        public void VypisVse()
        {
            if (seznamZvirat.Count == 0)
            {
                Console.WriteLine("Útulek je prázdný.");
                return;
            }

            Console.WriteLine("\n{0,-3} | {1,-12} | {2,-10} | {3,-4} | {4,-8} | {5,-15}", "ID", "Jméno", "Druh", "Věk", "Pohlaví", "Stav");
            Console.WriteLine(new string('-', 70));
            foreach (var z in seznamZvirat)
            {
                Console.WriteLine("{0,-3} | {1,-12} | {2,-10} | {3,-4} | {4,-8} | {5,-15}",
                    z.ID, z.Jmeno, z.Druh, z.Vek, z.Pohlavi, z.ZdravotniStav);
            }
        }

        public void VyhledatPodleDruhu(string druh)
        {
            var vysledek = seznamZvirat.Where(z => z.Druh.Equals(druh, StringComparison.OrdinalIgnoreCase)).ToList();
            VypisSeznam(vysledek);
        }

        public void VyhledatPodleJmena(string jmeno)
        {
            var vysledek = seznamZvirat.Where(z => z.Jmeno.Contains(jmeno, StringComparison.OrdinalIgnoreCase)).ToList();
            VypisSeznam(vysledek);
        }

        public void VyhledatPodleVeku(int vek, bool mensi)
        {
            var vysledek = mensi
                ? seznamZvirat.Where(z => z.Vek <= vek).ToList()
                : seznamZvirat.Where(z => z.Vek >= vek).ToList();
            VypisSeznam(vysledek);
        }

        public void OznacitAdopci(int id)
        {
            var zvire = seznamZvirat.FirstOrDefault(z => z.ID == id);
            if (zvire != null)
            {
                zvire.ZdravotniStav = "Adoptován";
                Console.WriteLine($"Zvíře {zvire.Jmeno} (ID: {id}) bylo úspěšně označeno jako adoptované.");
            }
            else
            {
                Console.WriteLine("Zvíře s tímto ID nebylo nalezeno.");
            }
        }

        public void Statistiky()
        {
            if (seznamZvirat.Count == 0)
            {
                Console.WriteLine("Útulek je prázdný, nelze spočítat statistiky.");
                return;
            }

            Console.WriteLine("\n--- STATISTIKY ÚTULKU ---");
            Console.WriteLine($"Celkový počet zvířat: {seznamZvirat.Count}");
            Console.WriteLine($"Průměrný věk: {seznamZvirat.Average(z => z.Vek):F1} let");
            Console.WriteLine($"Počet adoptovaných: {seznamZvirat.Count(z => z.ZdravotniStav.Equals("Adoptován", StringComparison.OrdinalIgnoreCase))}");

            var nejoblibenejsiDruh = seznamZvirat.GroupBy(z => z.Druh)
                                                 .OrderByDescending(g => g.Count())
                                                 .First().Key;
            Console.WriteLine($"Nejčastější druh: {nejoblibenejsiDruh}");
        }

        public void NacistZakladniData()
        {
            PridatZvire("Alík", "Pes", 3, "Samec", "V útulku", "Má rád piškoty");
            PridatZvire("Micka", "Kočka", 1, "Samice", "V útulku", "Zrzavá");
            PridatZvire("Blesk", "Pes", 5, "Samec", "Zdravý", "Rychlý běžec");
        }

        private void VypisSeznam(List<Zvire> seznam)
        {
            if (seznam.Count == 0)
            {
                Console.WriteLine("Nenalezena žádná zvířata.");
            }
            else
            {
                foreach (var z in seznam) Console.WriteLine(z.ToString());
            }
        }
    }
}
