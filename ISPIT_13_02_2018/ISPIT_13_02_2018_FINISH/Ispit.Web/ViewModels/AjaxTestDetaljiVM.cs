using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class AjaxTestDetaljiVM
    {
        public string Naziv { get; set; }
        public float ProcenatRealizacijeObaveze { get; set; }
        public int SaljiNotifikacijuXDanaUnaprijed { get; set; }
        public bool PonavljajNotifikacijuSvakiDanUnaprijed { get; set; }
        public int StanjeId { get; set; }
    }
}
