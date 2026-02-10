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
            Zvire nove = new Zvire(jmeno, druh, vek, pohlavi, DateTime.Now, stav, poznamka, "K adopci");
            seznamZvirat.Add(nove);
            Console.WriteLine("Uloženo.");
        }

        public void VypisVse()
        {
            if (seznamZvirat.Count == 0)
            {
                Console.WriteLine("Prázdno.");
                return;
            }

            foreach (Zvire z in seznamZvirat)
            {
                Console.WriteLine(z.ToString());
            }
        }

        public void VyhledatPodleDruhu(string druh)
        {
            bool nalezeno = false;
            foreach (Zvire z in seznamZvirat)
            {
                if (z.Druh.ToLower() == druh.ToLower())
                {
                    Console.WriteLine(z.ToString());
                    nalezeno = true;
                }
            }
            if (!nalezeno) Console.WriteLine("Nenalezeno.");
        }

        public void VyhledatPodleJmena(string jmeno)
        {
            bool nalezeno = false;
            foreach (Zvire z in seznamZvirat)
            {
                if (z.Jmeno.ToLower().Contains(jmeno.ToLower()))
                {
                    Console.WriteLine(z.ToString());
                    nalezeno = true;
                }
            }
            if (!nalezeno) Console.WriteLine("Nenalezeno.");
        }

        public void VyhledatPodleVeku(int vek, bool mensi)
        {
            bool nalezeno = false;
            foreach (Zvire z in seznamZvirat)
            {
                if ((mensi && z.Vek <= vek) || (!mensi && z.Vek >= vek))
                {
                    Console.WriteLine(z.ToString());
                    nalezeno = true;
                }
            }
            if (!nalezeno) Console.WriteLine("Nenalezeno.");
        }

        public void OznacitAdopci(int id)
        {
            foreach (Zvire z in seznamZvirat)
            {
                if (z.ID == id)
                {
                    z.Adopce = "Adoptován";
                    Console.WriteLine("Změněno.");
                    return;
                }
            }
            Console.WriteLine("Nenalezeno.");
        }

        public void Statistiky()
        {
            if (seznamZvirat.Count == 0) return;

            int soucetVeku = 0;
            int adoptovani = 0;

            foreach (Zvire z in seznamZvirat)
            {
                soucetVeku += z.Vek;
                if (z.Adopce == "Adoptován") adoptovani++;
            }

            double prumer = (double)soucetVeku / seznamZvirat.Count;

            Console.WriteLine($"Celkem: {seznamZvirat.Count}");
            Console.WriteLine($"Průměrný věk: {prumer:F1}");
            Console.WriteLine($"Adoptovaní: {adoptovani}");
        }

        public void NacistZakladniData()
        {
            PridatZvire("Alík", "Pes", 3, "Samec", "Zdravý", "");
            PridatZvire("Micka", "Kočka", 1, "Samice", "V útulku", "");
        }
    }
}
