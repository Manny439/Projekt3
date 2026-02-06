using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Zvire
    {
        public static int Cislovac = 0;
        public int ID { get; }
        public string Jmeno { get; set; }
        public string Druh { get; set; }
        public int Vek { get; set; }
        public string Pohlavi { get; set; }
        public DateTime DatumPrijmu { get; set; }
        public string ZdravotniStav { get; set; }
        public string Poznamka { get; set; }
        public Zvire(string jmeno, string druh, int vek, string pohlavi, DateTime datumprijmu, string zdravotnistav, string poznamka = "")
        {
            ID = Cislovac++;
            Jmeno = jmeno;
            Druh = druh;
            Vek = vek;
            Pohlavi = pohlavi;
            DatumPrijmu = datumprijmu;
            ZdravotniStav = zdravotnistav;
            Poznamka = poznamka;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Jmeno: {Jmeno}, Druh: {Druh}, Věk: {Vek}, Pohlaví: {Pohlavi}, Datum příjmu: {DatumPrijmu:dd.MM.yyyy}, Zdravotní stav: {ZdravotniStav}, Poznámka: {Poznamka}";
        }
    }
}
