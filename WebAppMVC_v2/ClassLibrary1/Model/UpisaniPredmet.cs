using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkExercise.Model
{
    public class UpisaniPredmet
    {
        public int UpisaniPredmetID { get; set; }
        public int? ZakljucnaOcjena { get; set; }
        public DateTime? DatumIspita { get; set; }

        public int PredmetID { get; set; }
        public Predmet Predmet { get; set; }

        public int UpisGodineID { get; set; }
        public UpisGodine UpisGodine { get; set; }
    }
}
