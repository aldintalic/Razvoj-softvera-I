using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Remotion.Linq.Clauses;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class OdjeljenjeController : Controller
    {
        private readonly MojContext db;
        public OdjeljenjeController(MojContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            List<OdjeljenjeIndexVM> model = db.Odjeljenje.Include(x => x.Nastavnik).Select(p => new OdjeljenjeIndexVM
            {
                Id = p.Id,
                Oznaka = p.Oznaka,
                PrebacenUViseOdjeljenje = p.IsPrebacenuViseOdjeljenje,
                Razred = p.Razred,
                Razrednik = p.Nastavnik.ImePrezime,
                SkolskaGodina = p.SkolskaGodina,
                ProsjekOcjena = Math.Round((float)db.DodjeljenPredmet
                                .Include(d => d.OdjeljenjeStavka)
                                .Where(d => d.OdjeljenjeStavka.OdjeljenjeId == p.Id)
                                .Average(s => (int?)s.ZakljucnoKrajGodine), 2)
            }).ToList();

            foreach (var item in model)
            {

                var x = (from dp in db.DodjeljenPredmet
                         join os in db.OdjeljenjeStavka on dp.OdjeljenjeStavkaId equals os.Id
                         join u in db.Ucenik on os.UcenikId equals u.Id
                         select new { os, dp, u } into t
                         where t.os.OdjeljenjeId == item.Id
                         group t by t.u.ImePrezime into g
                         select new NajboljiUcenikVM
                         {
                             ImePrezime = g.Key,
                             Prosjek = g.Average(d => d.dp.ZakljucnoKrajGodine)
                         }
                       ).OrderByDescending(o => o.Prosjek).FirstOrDefault();

                item.NajboljiUcenik = x != null ? x.ImePrezime : "NOT SET";
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Dodaj()
        {
            LoadViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Dodaj(OdjeljenjeDodajVM model)
        {
            Odjeljenje novo = new Odjeljenje
            {
                NastavnikID = model.NastavnikId,
                Oznaka = model.Oznaka,
                SkolskaGodina = model.SkolskaGodina,
                Razred = model.Razred,
                IsPrebacenuViseOdjeljenje = false,
            };

            db.Add(novo);
            db.SaveChanges();
            if (model.OdjeljenjeId != 0)
            {
                Odjeljenje staro = db.Odjeljenje.Where(i => i.Id == model.OdjeljenjeId).SingleOrDefault();
                if (staro != null)
                {
                    staro.IsPrebacenuViseOdjeljenje = true;
                    db.Update(staro);
                    db.SaveChanges();

                    List<OdjeljenjeStavka> stavke = db.OdjeljenjeStavka
                                        .Where(o => o.OdjeljenjeId == staro.Id
                                        && (db.DodjeljenPredmet.Where(c => c.OdjeljenjeStavka.UcenikId == o.UcenikId)
                                        .Count(c => c.ZakljucnoKrajGodine == 1) == 0)).OrderBy(o => o.Ucenik.ImePrezime).ToList();
                    int brDnevnik = 1;

                    List<Predmet> predmeti = db.Predmet.Where(p => p.Razred == novo.Razred).ToList();
                    foreach (var item in stavke)
                    {
                        OdjeljenjeStavka stavka = new OdjeljenjeStavka
                        {
                            BrojUDnevniku = brDnevnik++,
                            OdjeljenjeId = novo.Id,
                            UcenikId = item.UcenikId,
                        };

                        db.Add(stavka);
                        db.SaveChanges();

                        foreach (var it in predmeti)
                        {
                            DodjeljenPredmet novi = new DodjeljenPredmet
                            {
                                OdjeljenjeStavkaId = stavka.Id,
                                PredmetId = it.Id,
                                ZakljucnoKrajGodine = 0,
                                ZakljucnoPolugodiste = 0
                            };
                            db.Add(novi);
                            db.SaveChanges();
                        }
                    }
                }
                return Redirect("Index");
            }

            return View(model);
        }

        public ActionResult Obrisi(int id)
        {
            Odjeljenje o = db.Odjeljenje.Find(id);
            if (o != null)
            {
                List<DodjeljenPredmet> predmeti = db.DodjeljenPredmet.Where(p => p.OdjeljenjeStavka.OdjeljenjeId == id).ToList();
                foreach (var item in predmeti)
                    db.Remove(item);

                List<OdjeljenjeStavka> stavke = db.OdjeljenjeStavka.Where(s => s.OdjeljenjeId == id).ToList();
                foreach (var item in stavke)
                    db.Remove(item);

                db.Remove(o);
                db.SaveChanges();
            }
            return Redirect("Index");
        }

        public ActionResult Detalji(int id)
        {
            Odjeljenje o = db.Odjeljenje.Include(d => d.Nastavnik).Where(d => d.Id == id).SingleOrDefault();
            if (o != null)
            {

                OdjeljenjeDetaljiVM model = new OdjeljenjeDetaljiVM
                {
                    Id = o.Id,
                    Oznaka = o.Oznaka,
                    Razred = o.Razred,
                    Razrednik = o.Nastavnik.ImePrezime,
                    SkolskaGodina = o.SkolskaGodina,
                    BrojPredmeta = db.Predmet.Count(c => c.Razred == o.Razred)
                };

                return View(model);
            }
            return Redirect("Index");

        }

        public ActionResult GenerisiRedneBrojeve(int id)
        {
            Odjeljenje o = db.Odjeljenje.Find(id);

            if (o != null)
            {
                List<OdjeljenjeStavka> ucenici = db.OdjeljenjeStavka
                                .Where(d => d.Odjeljenje.Oznaka == o.Oznaka && o.Id==d.OdjeljenjeId)
                                .OrderBy(p=>p.Ucenik.ImePrezime)
                                .ToList();
                int brojac = 1;
                foreach (var item in ucenici)
                {
                    item.BrojUDnevniku = brojac++;
                }
                db.SaveChanges();
          
            }
                return Redirect("/Odjeljenje/Detalji/" + id);

        }

        private void LoadViewBag()
        {
            List<SelectListItem> Odjeljenja = new List<SelectListItem>();
            foreach (var item in db.Odjeljenje.Where(d => d.IsPrebacenuViseOdjeljenje == false).ToList())
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.SkolskaGodina + ", " + item.Oznaka;

                Odjeljenja.Add(x);
            }

            List<SelectListItem> Razrednici = new List<SelectListItem>();
            foreach (var item in db.Nastavnik.ToList())
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.NastavnikID.ToString();
                x.Text = item.ImePrezime;

                Razrednici.Add(x);
            }
            ViewBag.razrednici = Razrednici;
            ViewBag.odjeljenja = Odjeljenja;

        }
    }
}
