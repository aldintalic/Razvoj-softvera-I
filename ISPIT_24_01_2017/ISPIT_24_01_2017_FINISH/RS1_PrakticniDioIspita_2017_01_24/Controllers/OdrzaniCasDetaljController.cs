using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_PrakticniDioIspita_2017_01_24.EF;
using RS1_PrakticniDioIspita_2017_01_24.Models;
using RS1_PrakticniDioIspita_2017_01_24.ViewModels;

namespace RS1_PrakticniDioIspita_2017_01_24.Controllers
{
    public class OdrzaniCasDetaljController : Controller
    {
        private readonly MojContext db;
        public OdrzaniCasDetaljController(MojContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<CasoviIndexVM> model = db.Nastavnik.Select(x => new CasoviIndexVM
            {
                NastavnikId = x.Id,
                ImePrezime = x.Ime
            }).ToList();

            return View(model);
        }

        public IActionResult Detalji(int id)
        {
            List<OdrzaniCasDetaljIndexVM> model = db.OdrzaniCas
                                .Where(x => x.Angazovan.NastavnikId == id)
                                .Select(x => new OdrzaniCasDetaljIndexVM
                                {
                                   Predmet=x.Angazovan.Predmet.Naziv,
                                   DatumOdrzanogCasa=x.datum,
                                   Odjeljenje=x.Angazovan.Odjeljenje.Oznaka,
                                   BrojUcenikaUkupno=db.OdrzaniCasDetalj.Count(d=>d.OdrzaniCasId==x.Id),
                                   BrojPrisutnih=db.OdrzaniCasDetalj.Count(d=>d.OdrzaniCasId==x.Id && d.Odsutan==false),
                                    OdrzanCasId=x.Id
                                }).ToList();
            foreach (var item in model)
            {

                var result = db.OdrzaniCasDetalj
                            .Include(e=>e.OdrzaniCas)
                            .ThenInclude(e=>e.Angazovan)
                            .ThenInclude(e=>e.Predmet)
                            .Where(c => c.OdrzaniCas.Angazovan.Predmet.Naziv == item.Predmet)
                            .GroupBy(d => new { u = d.UpisUOdjeljenjeId })
                            .Select(g => new
                            {
                                id = g.Key.u,
                                pr = g.Average(p => p.Ocjena)
                            }).OrderByDescending(c => c.pr);

                item.NajboljiUcenikNaPredmetu = db.UpisUOdjeljenje
                                .Where(p => p.Id == result.First().id).Include(d => d.Ucenik)
                                .First().Ucenik.Ime;
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            OdrzaniCas o = db.OdrzaniCas.Include(d=>d.Angazovan)
                                        .ThenInclude(d=>d.Odjeljenje)
                                        .Include(d=>d.Angazovan.Predmet)
                                        .Where(d=>d.Id==id)
                                        .SingleOrDefault();
            OdrzanCasDetaljEditVM model = new OdrzanCasDetaljEditVM
            {
                Datum = o.datum,
                Odjeljenje = o.Angazovan.Odjeljenje.Oznaka+" / "+o.Angazovan.Predmet.Naziv,
                OdrzanCasId=o.Id,
                NastavnikId=o.Angazovan.NastavnikId??default(int)
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Edit(OdrzanCasDetaljEditVM model)
        {
            if (ModelState.IsValid)
            {
                OdrzaniCas o = db.OdrzaniCas.Find(model.OdrzanCasId);
                if (o != null)
                {
                    o.datum = model.Datum??default(DateTime);
                    db.Update(o);
                    db.SaveChanges();
                    return Redirect("/OdrzaniCasDetalj/Detalji/" + model.NastavnikId);
                }
            }
            return View(model);

        }

        
    }
}