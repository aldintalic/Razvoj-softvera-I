using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class OznaceniDogadajiDetaljiVM
    {
        public DateTime DatumDogadjaja { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public string OpisDogadjaja { get; set; }
        public string Nastavnik { get; set; }
        public int DogadjajId { get; set; }

    }
}
