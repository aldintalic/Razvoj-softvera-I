using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class OdrzanCas
    {
        public int Id { get; set; }
        public DateTime DatumOdrzanogCasa { get; set; }

        [ForeignKey(nameof(OdjeljenjeId))]
        public virtual Odjeljenje Odjeljenje { get; set; }
        public int OdjeljenjeId { get; set; }

        [ForeignKey(nameof(PredajePredmetId))]
        public PredajePredmet PredajePredmet { get; set; }
        public int PredajePredmetId { get; set; }

        public string SadrzajCasa { get; set; }

    }
}
