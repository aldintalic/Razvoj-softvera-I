using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Ispit_2017_06_21_v1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.ViewModels
{
    public class MaturskiIspitDodajVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Ovo polje je obavezno.")]
        public int? NastavnikId { get; set; }
        public Nastavnik Nastavnik { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        [DataType(DataType.DateTime,ErrorMessage ="Datum nije validan.")]
        public DateTime? Datum { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public int? OdjeljenjeId { get; set; }
        public Odjeljenje Odjeljenje { get; set; }

    }
}
