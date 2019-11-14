﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_PONG.Models
{
    public class Postovanje
    {
        public int PostivalacID { get; set; }
        public Igrac Postivalac{ get; set; }

        public int PostovaniID { get; set; }
        public Igrac Postovani { get; set; }

        public Postovanje(int postivalacID, int postovaniID)
        {
            PostivalacID = postivalacID;
            PostovaniID = postovaniID;

        }
    }
}
