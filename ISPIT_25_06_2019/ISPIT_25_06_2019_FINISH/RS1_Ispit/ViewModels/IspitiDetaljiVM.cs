using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class IspitiDetaljiVM
    {
        public int ispitId { get; set; }
        public string Predmet { get; set; }
        public string Nastavnik { get; set; }
        public string AkademskaGodina { get; set; }
        public string Datum { get; set; }
        public string Napomena { get; set; }
        public bool Zakljucano { get; set; }
    }
}
