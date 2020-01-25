using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.ViewModels
{
    public class CasoviDodajVM
    {
        public int AngazovanId { get; set; }
        [Required(ErrorMessage ="Ovo polje je obavezno.")]
        //[DataType(DataType.DateTime,ErrorMessage ="Morate unijeti datum.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Datum { get; set; }
        public int NastavnikId { get; set; }
        public int OdrzanCasId { get; set; }
    }
}
