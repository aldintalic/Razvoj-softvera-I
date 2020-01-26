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
            List<AjaxTestPrikaziVM> model = db.OdrzanCasDetalj.Where(x => x.OdrzanCasId == id).Select(x => new AjaxTestPrikaziVM
            {
                OdrzanCasDetaljId = x.Id,
                OpravdanoOdsutan = x.Prisutan == false ? x.OpravdanoOdsutan == true ? "DA" : "NE" : " ",
                Prisutan = x.Prisutan == true ? "Prisutan" : "Odsutan",
                Ucenik = x.OdjeljenjeStavka.Ucenik.ImePrezime,
                Ocjena = db.DodjeljenPredmet.Where(p => p.OdjeljenjeStavkaId == x.OdjeljenjeStavkaId && p.PredmetId == x.OdrzanCas.PredajePredmet.PredmetID).SingleOrDefault().ZakljucnoKrajGodine
            }).ToList();

            return PartialView(model);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            OdrzanCasDetalj o = db.OdrzanCasDetalj.Where(x => x.Id == id)
                    .Include(d => d.OdrzanCas)
                    .ThenInclude(d => d.PredajePredmet)
                    .Include(d => d.OdjeljenjeStavka)
                    .ThenInclude(d => d.Ucenik)
                    .SingleOrDefault();

            if (o != null)
            {
                AjaxTestEditVM model = new AjaxTestEditVM
                {
                    Ocjena = db.DodjeljenPredmet.Where(p => p.OdjeljenjeStavkaId == id && p.PredmetId == o.OdrzanCas.PredajePredmet.PredmetID).SingleOrDefault()!=null?
                    db.DodjeljenPredmet.Where(p => p.OdjeljenjeStavkaId == id && p.PredmetId == o.OdrzanCas.PredajePredmet.PredmetID).SingleOrDefault().ZakljucnoKrajGodine:-1,
                    OdzanCasDetaljId = id,
                    Prisutan = o.Prisutan,
                    OpravdanoOdsutan = o.OpravdanoOdsutan??default(bool),
                    Ucenik = o.OdjeljenjeStavka.Ucenik.ImePrezime,
                    Napomena = o.Napomena,
                };
                return PartialView(model);

            }
            return Redirect("/OdrzanaNastava/Index");
        }

        [HttpPost]
        public IActionResult Edit(AjaxTestEditVM model)
        {
            OdrzanCasDetalj o = db.OdrzanCasDetalj.Where(x => x.Id == model.OdzanCasDetaljId).Include(d => d.OdrzanCas).ThenInclude(d => d.PredajePredmet).SingleOrDefault();

            if (o != null)
            {
                if (model.Prisutan)
                {
                    DodjeljenPredmet d = db.DodjeljenPredmet.Where(p => p.OdjeljenjeStavkaId == o.OdjeljenjeStavkaId && p.PredmetId == o.OdrzanCas.PredajePredmet.PredmetID).SingleOrDefault();
                    if (d == null)
                    {
                        DodjeljenPredmet novi = new DodjeljenPredmet
                        {
                            OdjeljenjeStavkaId = o.OdjeljenjeStavkaId,
                            PredmetId = o.OdrzanCas.PredajePredmet.PredmetID,
                            ZakljucnoKrajGodine = model.Ocjena,
                            ZakljucnoPopravni = 0
                        };
                        db.Add(novi);
                    }
                    else
                    {
                        d.ZakljucnoKrajGodine = model.Ocjena;
                        db.Update(d);

                    }
                    db.SaveChanges();
                }
                else
                {
                    o.Napomena = model.Napomena;
                    o.OpravdanoOdsutan = model.OpravdanoOdsutan;
                    db.Update(o);
                    db.SaveChanges();
                }
                return Redirect("/AjaxTest/Prikazi/" + o.OdrzanCasId);
            }

            return Redirect("/OdrzanaNastava/Index");
        }

        public IActionResult Prisustvo(int id)
        {
            OdrzanCasDetalj o = db.OdrzanCasDetalj.Find(id);

            if (o != null)
            {
                if (o.Prisutan)
                {
                    o.Prisutan = false;
                    o.OpravdanoOdsutan = false;
                    o.Napomena = null;
                    db.Update(o);
                    db.SaveChanges();
                }
                else
                {
                    o.Prisutan = true;
                    db.Update(o);
                    db.SaveChanges();
                }
                //return Redirect("/OdrzanaNastava/Edit/" + o.OdrzanCasId);
                return Redirect("/AjaxTest/Prikazi/" + o.OdrzanCasId);
            }
            return Redirect("/OdrzanaNastava/Index");

        }

    }
}