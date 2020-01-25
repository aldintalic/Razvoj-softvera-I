using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_2017_06_21_v1.EF;
using RS1_Ispit_2017_06_21_v1.Models;
using RS1_Ispit_2017_06_21_v1.ViewModels;

namespace RS1_Ispit_2017_06_21_v1.Controllers
{
    public class AjaxTestController : Controller
    {
        private readonly MojContext db;
        public AjaxTestController(MojContext db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }

        public ActionResult GenerisiDiv(int id)
        {
            MaturskiIspit obj = db.MaturskiIspit.Find(id);

            if (obj == null)
                return Redirect("Greska");

            List<AjaxTestGenerisiDivVM> model = GetModelZaDiv(id);

            return PartialView(model);
        }

        public ActionResult Greska()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Uredi(int id)
        {
            MaturskiIspitStavka obj = db.MaturskiIspitStavka
                                .Where(x => x.Id == id)
                                .Include(x => x.UpisUOdjeljenje)
                                .ThenInclude(x => x.Ucenik)
                                .SingleOrDefault();
            if (obj == null)
                return View("Greska");

            AjaxTestUrediVM model = new AjaxTestUrediVM
            {
                Ucenik = obj.UpisUOdjeljenje.Ucenik.ImePrezime,
                Bodovi = obj.Bodovi,
                StavkaID = obj.Id
            };

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Uredi(AjaxTestUrediVM obj)
        {
            MaturskiIspitStavka x = db.MaturskiIspitStavka.Find(obj.StavkaID);
            List<AjaxTestGenerisiDivVM> model = GetModelZaDiv(x.MaturskiIspitId);
            if (x != null)
            {
                if (obj.Bodovi < 0 || obj.Bodovi > 100)
                    ModelState.AddModelError(nameof(obj.Bodovi), "Nije validan unos bodova. ");
                if (ModelState.ErrorCount == 0)
                {
                    x.Bodovi = obj.Bodovi;
                    db.Update(x);
                    db.SaveChanges();
                    model = GetModelZaDiv(x.MaturskiIspitId);

                    return PartialView("~/Views/AjaxTest/GenerisiDiv.cshtml", model);
                }
            }
            return View(obj);

        }
        private List<AjaxTestGenerisiDivVM> GetModelZaDiv(int id)
        {

            List<AjaxTestGenerisiDivVM> model = db.MaturskiIspitStavka
                  .Where(s => s.MaturskiIspitId == id)
                  .Include(p => p.UpisUOdjeljenje)
                  .ThenInclude(s => s.Ucenik)
                   .Select(s => new AjaxTestGenerisiDivVM
                   {
                       Id = s.Id,
                       Bodovi = s.Bodovi,
                       OpciUspjeh = s.UpisUOdjeljenje.OpciUspjeh,
                       Oslobodjen = s.Oslobodjen,
                       Ucenik = s.UpisUOdjeljenje.Ucenik.ImePrezime,
                       StavkaId=s.Id
                   }).ToList();

            return model;
        }

        public ActionResult PromijeniBodove(int id, int bodovi)
        {
            MaturskiIspitStavka obj = db.MaturskiIspitStavka
                                .Where(x => x.Id == id)
                                .Include(x => x.UpisUOdjeljenje)
                                .ThenInclude(x => x.Ucenik)
                                .SingleOrDefault();
            List<AjaxTestGenerisiDivVM> model = GetModelZaDiv(obj.MaturskiIspitId);

            if (obj == null)
                return View("Greska");

            if (bodovi<0 || bodovi > 100)
                ModelState.AddModelError("test", "Nije validan unos bodova.");
            if (ModelState.ErrorCount == 0)
            {
                obj.Bodovi = bodovi;
                db.Update(obj);
                db.SaveChanges();
                model = GetModelZaDiv(obj.MaturskiIspitId);
                return PartialView("~/Views/AjaxTest/GenerisiDiv.cshtml", model);
            }
            return View();

        }

        public ActionResult PromijeniStanje(int id)
        {
            MaturskiIspitStavka obj = db.MaturskiIspitStavka
                                .Where(x => x.Id == id)
                                .Include(x => x.UpisUOdjeljenje)
                                .ThenInclude(x => x.Ucenik)
                                .SingleOrDefault();
            List<AjaxTestGenerisiDivVM> model = GetModelZaDiv(obj.MaturskiIspitId);

            if (obj == null)
                return View("Greska");


            if (obj.Oslobodjen)
                obj.Oslobodjen = false;
            else
                obj.Oslobodjen = true;
            db.Update(obj);
            db.SaveChanges();
            model = GetModelZaDiv(obj.MaturskiIspitId);

            return PartialView("~/Views/AjaxTest/GenerisiDiv.cshtml", model);
        
        }
    }
}
