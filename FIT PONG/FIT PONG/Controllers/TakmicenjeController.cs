﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FIT_PONG.Controllers
{
    public class TakmicenjeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}