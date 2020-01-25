using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.ViewModels
{
    public class MaturskiIspitPrikazVM
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Odjeljenje  { get; set; }
        public string Ispitivac { get; set; }
        public double ProsjecniBodovi { get; set; }

    }
}
