using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkExercise.Model
{
    public class UpisGodine
    {
        public int UpisGodineID { get; set; }
        public int GodinaStudija { get; set; }
        public DateTime DatumUpisa { get; set; }
        public bool JelObnova{ get; set; }


        public int StudentID { get; set; }
        public Student Student { get; set; }          

    }
}
