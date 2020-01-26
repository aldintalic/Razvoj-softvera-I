using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzanaNastavaDetaljiVM
    {
        public string DatumOdrzanogCasa { get; set; }
        public string SkolskaGodinaOdjeljenje { get; set; }
        public string Predmet { get; set; }
        public List<string> OdsutniUcenici { get; set; }
        public int OdrzanCasId { get; set; }
    }
}
