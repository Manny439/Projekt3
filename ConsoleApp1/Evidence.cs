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
            Console.WriteLine("\n--- PŘEHLED ZVÍŘAT V ÚTULKU ---");
            if (seznamZvirat.Count == 0)
            {
                Console.WriteLine("Útulek je prázdný.");
                return;
            }

            foreach (var zvire in seznamZvirat)
            {
                Console.WriteLine(zvire.ToString());
            }
        }
        public void VyhledatPodleDruhu(string druh)
        {
            var vysledek = seznamZvirat.Where(z => z.Druh.Equals(druh, StringComparison.OrdinalIgnoreCase)).ToList();

            Console.WriteLine($"\n--- VÝSLEDKY VYHLEDÁVÁNÍ ({druh}) ---");
            if (vysledek.Count == 0)
            {
                Console.WriteLine("Žádné takové zvíře nenalezeno.");
            }
            else
            {
                foreach (var z in vysledek) Console.WriteLine(z.ToString());
            }
        }
    }
}
