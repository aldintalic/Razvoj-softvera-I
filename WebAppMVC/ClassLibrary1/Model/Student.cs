using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkExercise.Model
{
    public class Student
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }

        public int FakultetID { get; set; }
        public Fakultet Fakultet { get; set; }

        public int OpstinaRodjenjaID { get; set; }
        public Opstina OpstinaRodjenja { get; set; }

        public int OpstinaPrebivalistaID { get; set; }
        public Opstina OpstinaPrebivalista { get; set; }

    }
}
