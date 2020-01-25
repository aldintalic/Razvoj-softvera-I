using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class AjaxDetaljiVM
    {
        public string Proizvod { get; set; }
        public float Cijena { get; set; }
        public float Kolicina { get; set; }
        public float Popust { get; set; }
        public int FakturaId { get; set; }
        public int StavkaId { get; set; }
    }
}
