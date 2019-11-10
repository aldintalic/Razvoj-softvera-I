using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1.Model;

namespace EntityFrameworkExercise.Model
{
    public class Fakultet
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public int UniverzitetID { get; set; }
        public Univerzitet Univerzitet { get; set; }

    }
}
