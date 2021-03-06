﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjeIndexVM
    {
        public int Id { get; set; }
        public string SkolskaGodina { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public string Razrednik { get; set; }
        public bool PrebacenUViseOdjeljenje { get; set; }
        public double? ProsjekOcjena { get; set; }
        public string NajboljiUcenik { get; set; }
    }       
}
