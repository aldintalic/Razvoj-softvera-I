using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxTestEditVM
    {
        public int OdzanCasDetaljId { get; set; }
        public string Ucenik { get; set; }
        public int Ocjena { get; set; }
        public string Napomena { get; set; }
        public bool OpravdanoOdsutan { get; set; }
        public bool Prisutan { get; set; }
    }
}
