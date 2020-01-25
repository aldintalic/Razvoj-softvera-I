using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit.Data;
using Ispit.Data.EntityModels;
using Ispit.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class AjaxTestController : Controller
    {
        private readonly MyContext db;

        public AjaxTestController(MyContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }

        public IActionResult Detalji(int id)
        {
            OznacenDogadjaj d = db.OznacenDogadjaj.Where(x => x.DogadjajID == id).SingleOrDefault();

            if (d != null)
            {
                List<AjaxTestDetaljiVM> model = db.StanjeObaveze
                                    .Where(p => p.OznacenDogadjajID == d.ID)
                                    .Select(c => new AjaxTestDetaljiVM
                                    {
                                        Naziv = c.Obaveza.Naziv,
                                        PonavljajNotifikacijuSvakiDanUnaprijed = c.NotifikacijeRekurizivno,
                                        SaljiNotifikacijuXDanaUnaprijed = c.NotifikacijaDanaPrije,
                                        ProcenatRealizacijeObaveze = c.IzvrsenoProcentualno,
                                        StanjeId=c.Id
                                    }).ToList();

                return PartialView(model);
            }
            return Redirect("Greska");

        }

        [HttpGet]
        public IActionResult Uredi(int id)
        {
            StanjeObaveze s = db.StanjeObaveze.Where(x => x.Id == id).Include(d => d.Obaveza).SingleOrDefault();
            if (s != null)
            {
                AjaxTestUrediVM model = new AjaxTestUrediVM
                {
                    StanjeId = s.Id,
                    Obaveza = s.Obaveza.Naziv,
                    ZavrsenoProcentualno=s.IzvrsenoProcentualno
                };
                return PartialView(model);
            }
            return PartialView("Greska");
        }

        [HttpPost]
        public IActionResult Uredi(AjaxTestUrediVM model)
        {
            StanjeObaveze s = db.StanjeObaveze.Where(d => d.Id == model.StanjeId).Include(p => p.OznacenDogadjaj).SingleOrDefault();
            if (s != null && model.ZavrsenoProcentualno>=0 && model.ZavrsenoProcentualno<=100)
            {
                s.IzvrsenoProcentualno = model.ZavrsenoProcentualno;
                db.Update(s);
                db.SaveChanges();

            }
            return Redirect("/AjaxTest/Detalji/" + s.OznacenDogadjaj.DogadjajID);
        }
    }
}