using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkExercise.Model;

namespace EntityFrameworkExercise.ViewsModels
{
    public class StudentZadnjaGodinaVM
    {
        public UpisGodine GodinaStudija { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int StudentID { get; set; }
        public int SumaECTS { get; set; }

    }
}
