using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_PrakticniDioIspita_2017_01_24.EF;
using RS1_PrakticniDioIspita_2017_01_24.Models;
using RS1_PrakticniDioIspita_2017_01_24.ViewModels;

namespace RS1_PrakticniDioIspita_2017_01_24.Controllers
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

        public ActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }

        public IActionResult Prikazi(int id)
        {
            List<AjaxTestPrikaziVM> model = db.OdrzaniCasDetalj.Where(x => x.OdrzaniCasId == id)
                               .Include(x => x.UpisUOdjeljenje)
                               .ThenInclude(x => x.Ucenik)
                               .Select(x => new AjaxTestPrikaziVM
                               {
                                   Ucenik = x.UpisUOdjeljenje.Ucenik.Ime,
                                   Ocjena = x.Ocjena ?? default(int),
                                   Prisutan = !x.Odsutan,
                                   OpravdanoOdsutan = x.OpravdanoOdsutan ?? default(bool),
                                   OdrzanCasDetaljId = x.Id
                               }).OrderBy(x => x.Ucenik).ToList();

            return PartialView(model);
        }

        public IActionResult PromijeniPrisustvo(int id)
        {
            OdrzaniCasDetalj o = db.OdrzaniCasDetalj.Find(id);
            if (o != null)
            {
                o.Odsutan = o.Odsutan ? false : true;
                db.Update(o);
                db.SaveChanges();
            }
            return Redirect("/AjaxTest/Prikazi/" + o.OdrzaniCasId);
        }

        public IActionResult Greska()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Uredi(int id)
        {
            OdrzaniCasDetalj o = db.OdrzaniCasDetalj.Include(x => x.UpisUOdjeljenje).ThenInclude(x => x.Ucenik).Where(x => x.Id == id).SingleOrDefault();
            if (o != null)
            {
                AjaxTestUrediVM model = new AjaxTestUrediVM
                {
                    Ocjena = o.Ocjena,
                    OdrzanCasDetaljId = o.Id,
                    Odsutan = o.Odsutan,
                    OpravdanoOdsutan = o.OpravdanoOdsutan ?? default(bool),
                    Ucenik = o.UpisUOdjeljenje.Ucenik.Ime
                };

                return PartialView(model);
            }
            return Redirect("Greska");
        }

        [HttpPost]
        public IActionResult Uredi(AjaxTestUrediVM model)
        {
            OdrzaniCasDetalj o = db.OdrzaniCasDetalj.Find(model.OdrzanCasDetaljId);
            if (o != null)
            {
                if (model.Odsutan)
                {
                    o.OpravdanoOdsutan = model.OpravdanoOdsutan;
                }
                else
                {
                    if (model.Ocjena > 0 && model.Ocjena <= 5)
                        o.Ocjena = model.Ocjena;
                }
                db.Update(o);
                db.SaveChanges();
                return Redirect("/AjaxTest/Prikazi/" + o.OdrzaniCasId);
            }

            return View(model);
        }

    }
}