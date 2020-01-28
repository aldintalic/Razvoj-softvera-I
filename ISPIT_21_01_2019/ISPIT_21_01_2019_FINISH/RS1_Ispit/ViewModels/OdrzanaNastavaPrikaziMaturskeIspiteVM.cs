using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzanaNastavaPrikaziMaturskeIspiteVM
    {
        public string Datum { get; set; }
        public string Skola { get; set; }
        public string Predmet { get; set; }
        public List<String> NisuPristupiliUcenici { get; set; }
        public int MaturskiIspitId { get; set; }
    }
}
