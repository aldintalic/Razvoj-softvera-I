using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.ViewModels
{
    public class AjaxTestPrikaziVM
    {
        public string Ucenik { get; set; }
        public int Ocjena { get; set; }
        public bool Prisutan { get; set; }
        public bool OpravdanoOdsutan { get; set; }
        public int OdrzanCasDetaljId { get; set; }
    }
}
