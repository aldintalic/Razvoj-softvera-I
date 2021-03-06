﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class IspitStavka
    {
        public int Id { get; set; }
        public bool Pristupio { get; set; }
        public int? Ocjena { get; set; }

        [ForeignKey(nameof(IspitId))]
        public Ispit Ispit { get; set; }
        public int IspitId { get; set; }

        [ForeignKey(nameof(UpisGodineId))]
        public UpisGodine UpisGodine { get; set; }
        public int UpisGodineId { get; set; }
    }
}
