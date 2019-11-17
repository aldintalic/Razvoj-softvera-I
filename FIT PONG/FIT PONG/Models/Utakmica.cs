﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_PONG.Models
{
    public class Utakmica
    {
        [Required]
        public int ID { get; set; }

        [RegularExpression(@"^[0-9]+$")]
        public int BrojUtakmice { get; set; }
        public DateTime DatumVrijeme { get; set; }
        [StringLength(10)]
        public string Rezultat { get; set; }

        public Runda Runda{ get; set; }
        public int RundaID { get; set; }

        public Tip_Utakmice TipUtakmice{ get; set; }
        public int TipUtakmiceID { get; set; }

        public Status_Utakmice Status { get; set; }
        public int StatusID { get; set; }
    }
}
