using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class AjaxTestController : Controller
    {
        private readonly MojContext db;

        public AjaxTestController(MojContext db)
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

        public IActionResult Prikazi(int id)
        {
            Ispit i = db.Ispit.Find(id);

            if (i != null)
            {
                List<AjaxTestPrikaziVM> model = db.IspitStavka.Where(d => d.IspitId == id).Include(d => d.UpisGodine).ThenInclude(d => d.Student).Select(d => new AjaxTestPrikaziVM
                {
                    IspitStavkaId = d.Id,
                    Ocjena = d.Ocjena != null ? d.Ocjena.ToString() : " ",
                    PristupioIspitu = d.Pristupio == true ? "Pristupio" : "NijePristupio",
                    Student = d.UpisGodine.Student.Ime + " " + d.UpisGodine.Student.Prezime
                }).ToList();
                ViewBag.datum = i.Datum;
                ViewBag.zakljucan = i.EvidentiraniRezultati!=null && i.EvidentiraniRezultati==true?"da":"ne";
                return PartialView(model);
            }
            return Redirect("Greska");
        }

        [HttpGet]
        public IActionResult Uredi(int id)
        {
            IspitStavka stavka = db.IspitStavka.Where(d => d.Id == id).Include(d => d.UpisGodine).ThenInclude(d => d.Student).SingleOrDefault();
            if (stavka != null)
            {
                AjaxTestUrediVM model = new AjaxTestUrediVM
                {
                    IspitStavkaId = stavka.Id,
                    Ocjena = stavka.Ocjena ?? default(int),
                    Student = stavka.UpisGodine.Student.Ime + " " + stavka.UpisGodine.Student.Prezime
                };
                return View(model);

            }
            return Redirect("Greska");

        }

        [HttpPost]
        public IActionResult Uredi(AjaxTestUrediVM model)
        {
            IspitStavka stavka = db.IspitStavka.Find(model.IspitStavkaId);
            if (stavka != null)
            {
                stavka.Ocjena = model.Ocjena;
                db.Update(stavka);
                db.SaveChanges();
                return Redirect("/AjaxTest/Prikazi/" + stavka.IspitId);
            }
            return Redirect("Greska");

        }

        public IActionResult UnesiOcjenu(int id, int ocjena)
        {
            IspitStavka stavka = db.IspitStavka.Find(id);
            if (stavka != null)
            {
                if(ocjena>=5 && ocjena <= 10)
                {
                    stavka.Ocjena = ocjena;
                    db.Update(stavka);
                    db.SaveChanges();
                    return Redirect("/AjaxTest/Prikazi/" + stavka.IspitId);
                }

            }

            return Redirect("Greska");
        }

        public IActionResult Greska()
        {
            return PartialView();
        }
    }
}