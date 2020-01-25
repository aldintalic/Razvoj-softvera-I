using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.ViewModels
{
    public class OdrzaniCasDetaljIndexVM
    {
        public DateTime DatumOdrzanogCasa { get; set; }
        public string Odjeljenje { get; set; }
        public int BrojPrisutnih { get; set; }
        public int BrojUcenikaUkupno { get; set; }
        public string Predmet { get; set; }
        public string NajboljiUcenikNaPredmetu { get; set; }
        public int OdrzanCasId { get; set; }
    }
}
