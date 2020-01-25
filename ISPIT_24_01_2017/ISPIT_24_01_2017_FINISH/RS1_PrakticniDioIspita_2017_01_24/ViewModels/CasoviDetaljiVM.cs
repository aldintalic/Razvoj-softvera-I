using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.ViewModels
{
    public class CasoviDetaljiVM
    {
        public DateTime DatumOdrzanogCasa { get; set; }
        public string Odjeljenje { get; set; }
        public string Predmet { get; set; }
        public int AngazovanId { get; set; }
    }
}
