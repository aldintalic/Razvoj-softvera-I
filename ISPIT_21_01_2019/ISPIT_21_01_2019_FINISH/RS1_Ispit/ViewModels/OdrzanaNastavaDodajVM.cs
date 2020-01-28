using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzanaNastavaDodajVM
    {
        public int SkolaId { get; set; }
        public string Nastavnik { get; set; }
        public string SkolskaGodina { get; set; }
        public DateTime Datum { get; set; }
        public int PredajePredmetId { get; set; }
    }
}
