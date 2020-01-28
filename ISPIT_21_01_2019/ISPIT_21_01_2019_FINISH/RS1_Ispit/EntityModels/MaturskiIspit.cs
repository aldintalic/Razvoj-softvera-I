using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class MaturskiIspit
    {
        public int Id { get; set; }

        [ForeignKey(nameof(PredajePredmetId))]
        public virtual PredajePredmet PredajePredmet { get; set; }
        public int PredajePredmetId { get; set; }

        public DateTime DatumOdrzavanja { get; set; }
        public string Napomena { get; set; }
    }
}
