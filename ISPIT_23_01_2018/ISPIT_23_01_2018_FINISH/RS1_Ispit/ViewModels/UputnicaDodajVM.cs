using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class UputnicaDodajVM
    {
        public int LjekarId { get; set; }

        [Required(ErrorMessage ="Ovo polje je obavezno.")]
        [DataType(DataType.DateTime)]
        public DateTime DatumUputnice { get; set; }
        public int PacijentId { get; set; }
        public int VrstaPretrageId { get; set; }
    }
}
