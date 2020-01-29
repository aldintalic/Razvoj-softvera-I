using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class IspitiIndexVM
    {
        public string NazivPredmeta { get; set; }
        public string AkademskaGodina { get; set; }
        public string ImeIPrezimeNastavnika { get; set; }
        public int BrojOdrzanihCasova { get; set; }
        public int BrojStudenataNaPredmetu { get; set; }
        public int AngazovanId { get; set; }
    }
}
