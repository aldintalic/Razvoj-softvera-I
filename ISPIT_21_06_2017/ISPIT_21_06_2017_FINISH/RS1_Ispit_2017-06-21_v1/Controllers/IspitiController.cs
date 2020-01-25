using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_2017_06_21_v1.EF;
using RS1_Ispit_2017_06_21_v1.Models;
using RS1_Ispit_2017_06_21_v1.ViewModels;

namespace RS1_Ispit_2017_06_21_v1.Controllers
{
    public class IspitiController : Controller
    {
        private readonly MojContext db;

        public IspitiController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {

            List<MaturskiIspitPrikazVM> obj = db.MaturskiIspit.Include(p=>p.Odjeljenje).Include(n => n.Nastavnik).Select(x => new MaturskiIspitPrikazVM
            {
                Id = x.Id,
                Datum = x.Datum,
                Ispitivac = x.Nastavnik.ImePrezime,
                Odjeljenje = x.Odjeljenje.Naziv,
                ProsjecniBodovi = Math.Round(db.MaturskiIspitStavka.Where(s => s.MaturskiIspitId == x.Id).Average(s => s.Bodovi).GetValueOrDefault(), 2)
            }).ToList();

            return View(obj);
        }

        [HttpPost]
        public IActionResult Dodaj(MaturskiIspitDodajVM obj)
        {
            if (ModelState.IsValid) {

                MaturskiIspit novi = new MaturskiIspit
                {
                    Datum = obj.Datum??default,
                    NastavnikId = obj.NastavnikId??default,
                    OdjeljenjeId = obj.OdjeljenjeId??default
                };
                db.MaturskiIspit.Add(novi);
                db.SaveChanges();

                foreach (var item in db.UpisUOdjeljenje.Where(x => x.OdjeljenjeId == novi.OdjeljenjeId && x.OpciUspjeh>1).ToList())
                {
                        bool oslobodjen = false;
                        if (item.OpciUspjeh == 5)
                            oslobodjen = true;

                    MaturskiIspitStavka dd = (from mis in db.MaturskiIspitStavka
                                              join uo in db.UpisUOdjeljenje on mis.UpisUOdjeljenjeId equals uo.Id
                                              join u in db.Ucenik on uo.UcenikId equals u.Id
                                              where u.Id == item.UcenikId
                                              select new MaturskiIspitStavka
                                              {
                                                  Id = mis.Id,
                                                  Bodovi = mis.Bodovi,
                                                  MaturskiIspitId = mis.MaturskiIspitId,
                                                  Oslobodjen = mis.Oslobodjen,
                                                  UpisUOdjeljenjeId = mis.UpisUOdjeljenjeId
                                              }).LastOrDefault();

                    if (dd==null || dd.Bodovi == null || dd.Bodovi<=50)
                    {
                        db.MaturskiIspitStavka.Add(new MaturskiIspitStavka
                        {
                            Bodovi = null,
                            MaturskiIspitId = novi.Id,
                            Oslobodjen = oslobodjen,
                            UpisUOdjeljenjeId = item.Id,
                        });
                    }
                db.SaveChanges();
                }

                return Redirect("Index");
            }

            LoadViewBag();
            return View(obj);
            
        }

        [HttpGet]
        public IActionResult Dodaj()
        {
            LoadViewBag();

            return View();
        }

        public void LoadViewBag()
        {
            List<SelectListItem> nastavnici = new List<SelectListItem>();
            foreach (var item in db.Nastavnik.ToList())
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.ImePrezime;
                nastavnici.Add(x);
            }
            ViewBag.nastavnici = nastavnici;

            List<SelectListItem> odjeljenja = new List<SelectListItem>();
            foreach (var item in db.Odjeljenje.ToList())
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text =  item.Naziv;
                odjeljenja.Add(x);
            }
            ViewBag.odjeljenja= odjeljenja;

        }

        public IActionResult Detalji(int id)
        {
            MaturskiIspit obj = db.MaturskiIspit.Include(p => p.Odjeljenje).Include(n => n.Nastavnik).Where(x => x.Id == id).SingleOrDefault();
            if (obj == null)
                return Redirect("Greska");

            MaturskiIspitPrikazVM model = new MaturskiIspitPrikazVM
            {
                Id = obj.Id,
                Datum = obj.Datum,
                Ispitivac = obj.Nastavnik.ImePrezime,
                Odjeljenje = obj.Odjeljenje.Naziv,
            };

            return View(model);
        }

        public IActionResult Greska()
        {
            return View();
        }
    }
}
