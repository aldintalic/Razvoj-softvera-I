using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjeDodajVM
    {
        public int Id { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public int NastavnikId { get; set; }
        public int? OdjeljenjeId { get; set; }
        public string SkolskaGodina { get; set; }


    }
}
