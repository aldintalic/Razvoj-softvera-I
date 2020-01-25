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
    public class CasoviController : Controller
    {
        private readonly MojContext db;
        public CasoviController(MojContext db)
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
            Nastavnik n = db.Nastavnik.Find(id);
            if (n != null)
            {
                List<CasoviDetaljiVM> model = db.OdrzaniCas
                                        .Where(x => x.Angazovan.NastavnikId == id)
                                        .Select(x => new CasoviDetaljiVM
                                        {
                                            DatumOdrzanogCasa = x.datum,
                                            Odjeljenje = x.Angazovan.Odjeljenje.Oznaka,
                                            Predmet = x.Angazovan.Predmet.Naziv,
                                            AngazovanId=x.AngazovanId??default(int)
                                        }).ToList();
                ViewBag.nastavnikId = id;
                return View(model);
            }
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Dodaj(int id)
        {
            LoadViewBag(id);
            CasoviDodajVM model = new CasoviDodajVM
            {
                NastavnikId = id,
                AngazovanId=0,
                Datum=null
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Dodaj(CasoviDodajVM model)
        {
            Angazovan a = db.Angazovan.Find(model.AngazovanId);
            if (ModelState.IsValid)
            {

                List<UpisUOdjeljenje> ucenici = db.UpisUOdjeljenje
                                .Where(x=>x.OdjeljenjeId==a.OdjeljenjeId).ToList();

                OdrzaniCas noviOdrzanCas = new OdrzaniCas
                {
                    AngazovanId = model.AngazovanId,
                    datum = model.Datum??default(DateTime)
                };
                db.Add(noviOdrzanCas);
                db.SaveChanges();

                foreach (var item in ucenici)
                {
                    OdrzaniCasDetalj stavka = new OdrzaniCasDetalj
                    {
                        OdrzaniCasId = noviOdrzanCas.Id,
                        UpisUOdjeljenjeId = item.Id,
                        Odsutan = false
                    };
                    db.Add(stavka);
                    db.SaveChanges();
                }
                return Redirect("/Casovi/Detalji/" + a.NastavnikId);

            }

            LoadViewBag(model.NastavnikId);
            return View(model);


        }
        
        [HttpGet]
        public IActionResult Edit(int id, DateTime datum)
        {
            Angazovan a = db.Angazovan.Find(id);
            if (a != null)
            {
                OdrzaniCas o = db.OdrzaniCas.Where(d => d.AngazovanId == id && d.datum==datum).SingleOrDefault();
                CasoviDodajVM model = new CasoviDodajVM
                {
                    AngazovanId = a.Id,
                    Datum = o.datum,
                    NastavnikId = a.NastavnikId??default(int),
                    OdrzanCasId=o.Id
                };
                LoadViewBag(a.NastavnikId??default(int));
                return View(model);
            }
            return Redirect("/Casovi");
        }

        [HttpPost]
        public IActionResult Edit(CasoviDodajVM model)
        {
            if (ModelState.IsValid)
            {
                Angazovan a = db.Angazovan.Find(model.AngazovanId);
                OdrzaniCas o = db.OdrzaniCas.Find(model.OdrzanCasId);
                a.Id = model.AngazovanId;
                o.AngazovanId = model.AngazovanId;
                o.datum = model.Datum ?? default(DateTime);
                db.Update(a);
                db.Update(o);
                db.SaveChanges();
                return Redirect("/Casovi/Detalji/" + model.NastavnikId);
            }
            LoadViewBag(model.NastavnikId);
            return View(model);
        }

        private void LoadViewBag(int id)
        {
            List<SelectListItem> odjeljenjaPredmeti = new List<SelectListItem>();
            List<Angazovan> lista = db.Angazovan
                            .Where(x => x.NastavnikId == id)
                            .Include(x => x.Odjeljenje)
                            .Include(x => x.Predmet)
                            .ToList();
            foreach (var item in lista)
            {
                SelectListItem s = new SelectListItem();
                s.Value = item.Id.ToString();
                s.Text = item.Odjeljenje.Oznaka + " / " + item.Predmet.Naziv;
                odjeljenjaPredmeti.Add(s);
            }
            ViewBag.odjeljenjaPredmeti = odjeljenjaPredmeti;
        }
    }
}