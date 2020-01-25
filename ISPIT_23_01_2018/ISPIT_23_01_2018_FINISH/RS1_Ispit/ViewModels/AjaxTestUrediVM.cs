using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxTestUrediVM
    {
        public int RezultatId { get; set; }
        public string Pretraga { get; set; }
        public double? NumerickaVrijednost { get; set; }
        public string Vrijednost { get; set; }
        public string VrstaVr { get; set; }
        public int? ModalitetId { get; set; }
    }
}
