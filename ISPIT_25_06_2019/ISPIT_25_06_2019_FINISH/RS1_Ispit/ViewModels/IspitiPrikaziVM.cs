using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class IspitiPrikaziVM
    {
        public string DatumIspita { get; set; }
        public int BrojStudenataPolozili { get; set; }
        public int BrojPrijavljenih { get; set; }
        public string EvidentiraniRezultati { get; set; }
        public int IspitId { get; set; }
    }
}
