using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class OznaceniDogadajiPrikazVM
    {
        public DateTime DatumDogadjaja { get; set; }
        public string Nastavnik { get; set; }
        public string OpisDogadjaja { get; set; }
        public int BrojObaveza { get; set; }
        public float IzvrsenoProcentualno { get; set; }
        public bool OznacenDogadjaj { get; set; }
        public int DogadjajId { get; set; }
        public int KorisnikId { get; set; }
    }
}
