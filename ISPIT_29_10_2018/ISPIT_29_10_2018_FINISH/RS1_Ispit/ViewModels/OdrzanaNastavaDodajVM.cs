using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzanaNastavaDodajVM
    {
        public int NastavnikId { get; set; }
        public string Nastavnik { get; set; }
        public DateTime DatumOdrzanogCasa { get; set; }
        public int PredajePredmetId { get; set; }

    }
}
