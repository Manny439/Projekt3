using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Evidence
    {
        private List<Zvire> seznamZvirat = new List<Zvire>();
        private int dalsiId = 1;

        public void PridatZvire(string jmeno, string druh, int vek, string pohlavi)
        {
            Zvire nove = new Zvire(dalsiId++, jmeno, druh, vek, pohlavi);
            seznamZvirat.Add(nove);
            Console.WriteLine($"Zvíře {jmeno} bylo přidáno pod názvem Evidence.");
        }
    }
}
