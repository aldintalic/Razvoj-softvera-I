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
            MaturskiIspit m = db.MaturskiIspit.Find(id);
            if (m != null)
            {
                List<AjaxTestPrikaziVM> model = db.MaturskiIspitStavka.Include(d=>d.OdjeljenjeStavka).ThenInclude(d=>d.Ucenik).Where(d => d.MaturskiIspitId == id).Select(d => new AjaxTestPrikaziVM
                {
                    MaturskiIspitStavkaId=d.id,
                    RezultatMaturskogIspita=d.RezultatIspita!=null?d.RezultatIspita.ToString():"X",
                    PristupioIspitu=d.Prisutan==true?"DA":"NE",
                    Ucenik=d.OdjeljenjeStavka.Ucenik.ImePrezime,
                    ProsjekOcjena=(float)db.DodjeljenPredmet.Where(f=>f.OdjeljenjeStavkaId==d.OdjeljenjeStavkaId).Average(x=>x.ZakljucnoKrajGodine)
                }).ToList();

                return PartialView(model);
            }

            return Redirect("Greska");

        }

        public IActionResult Bodovi(int id, float bodovi)
        {
            MaturskiIspitStavka m = db.MaturskiIspitStavka.Find(id);
            if (m != null)
            {
                if(bodovi>=0 && bodovi <= 100)
                {
                    m.RezultatIspita = bodovi;
                    m.Prisutan = true;
                    db.Update(m);
                    db.SaveChanges();
                    return Redirect("/AjaxTest/Prikazi/" + m.MaturskiIspitId);
                }

            }
            return Redirect("Greska");

        }
        [HttpGet]
        public IActionResult Uredi(int id)
        {
            MaturskiIspitStavka m = db.MaturskiIspitStavka.Include(d => d.OdjeljenjeStavka).ThenInclude(d => d.Ucenik).Where(d => d.id == id).SingleOrDefault();
            if (m != null)
            {
                AjaxTestUrediVM model = new AjaxTestUrediVM
                {
                    Bodovi=m.RezultatIspita??default(float),
                    MaturskiIspitStavkaId=m.id,
                    Ucenik=m.OdjeljenjeStavka.Ucenik.ImePrezime

                };
                return PartialView(model);
            }
            return Redirect("/OdrzanaNastava/Index");
        }

        [HttpPost]
        public IActionResult Uredi(AjaxTestUrediVM model)
        {
            MaturskiIspitStavka m = db.MaturskiIspitStavka.Find(model.MaturskiIspitStavkaId);

            if (m != null)
            {
                m.RezultatIspita = model.Bodovi;
                db.Update(m);
                db.SaveChanges();

                return Redirect("/AjaxTest/Prikazi/" + m.MaturskiIspitId);
            };
            return Redirect("/OdrzanaNastava/Index");
        }

        public IActionResult Prisutan(int id)
        {
            MaturskiIspitStavka m = db.MaturskiIspitStavka.Find(id);
            if (m != null)
            {
                if (m.Prisutan == true)
                    m.Prisutan = false;
                else
                    m.Prisutan = true;
                db.Update(m);
                db.SaveChanges();
                return Redirect("/AjaxTest/Prikazi/" + m.MaturskiIspitId);

            }
            return Redirect("Greska");
        }

        public IActionResult Greska()
        {
            return PartialView();
        }
    }
}