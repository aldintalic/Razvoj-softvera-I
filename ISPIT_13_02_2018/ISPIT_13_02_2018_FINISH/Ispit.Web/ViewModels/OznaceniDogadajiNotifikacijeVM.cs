using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class OznaceniDogadajiNotifikacijeVM
    {
        public string Dogadjaj { get; set; }
        public DateTime Datum { get; set; }
        public string Obaveza { get; set; }
        public bool Rekurzivno { get; set; }
        public bool Procitana { get; set; }
        public int StanjeId { get; set; }

    }
}
