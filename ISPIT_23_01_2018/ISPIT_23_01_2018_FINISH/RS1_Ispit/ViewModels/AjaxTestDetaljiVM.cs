using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxTestDetaljiVM
    {
        public string Pretraga { get; set; }
        public string IzmjerenaVrijednost { get; set; }
        public string JMJ { get; set; }
        public int RezultatId { get; set; }
        public bool IsZavrsen { get; set; }
        public bool ReferentnaVrijednostMod { get; set; }
        public double? ReferentnaVrijednostMin { get; set; }
        public double? ReferentnaVrijednostMax { get; set; }
        public string Vrsta { get; set; }
        public List<SelectListItem> Modaliteti { get; set; }

    }
}
