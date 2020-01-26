using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzanaNastavaEditVM
    {
        public DateTime DatumOdrzanogCasa { get; set; }
        public string Odjeljenje { get; set; }
        public string SadrzajCasa { get; set; }
        public int OdrzanCasId { get; set; }
    }
}
