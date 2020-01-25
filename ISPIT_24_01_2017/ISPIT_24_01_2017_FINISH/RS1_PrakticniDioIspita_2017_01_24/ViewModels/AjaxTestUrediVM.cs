using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.ViewModels
{
    public class AjaxTestUrediVM
    {
        public int OdrzanCasDetaljId { get; set; }
        public string Ucenik { get; set; }
        [Required(ErrorMessage ="Ovo je obavezno polje.")]
        public int? Ocjena { get; set; }
        public bool OpravdanoOdsutan { get; set; }
        public bool Odsutan { get; set; }
    }
}
