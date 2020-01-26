using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class OdrzanaNastavaController : Controller
    {
        private readonly MojContext db;

        public OdrzanaNastavaController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<OdrzanaNastavaIndexVM> model = db.Nastavnik.Select(x => new OdrzanaNastavaIndexVM
            {
                Skola = x.Skola.Naziv,
                ImePrezimeNastavnika = x.Ime + " " + x.Prezime,
                NastavnikId = x.Id
            }).ToList();


            return View(model);
        }

        public IActionResult Detalji(int id)
        {
            Nastavnik n = db.Nastavnik.Find(id);
            if (n != null)
            {
                List<OdrzanaNastavaDetaljiVM> model = db.OdrzanCas.Where(x => x.PredajePredmet.NastavnikID == id).Select(x => new OdrzanaNastavaDetaljiVM
                {
                    OdrzanCasId=x.Id,
                    DatumOdrzanogCasa = x.DatumOdrzanogCasa.ToShortDateString(),
                    Predmet = x.PredajePredmet.Predmet.Naziv,
                    SkolskaGodinaOdjeljenje = x.Odjeljenje.SkolskaGodina.Naziv + " " + x.Odjeljenje.Oznaka,
                    OdsutniUcenici = db.OdrzanCasDetalj.Where(o => o.OdrzanCasId == x.Id && !o.Prisutan).Include(d => d.OdjeljenjeStavka).ThenInclude(d => d.Ucenik).Select(d => d.OdjeljenjeStavka.Ucenik.ImePrezime).ToList()
                }).ToList();
                ViewBag.nastavnikId = id;
                return View(model);
            }
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Dodaj(int id)
        {
            Nastavnik n = db.Nastavnik.Find(id);
            if (n != null)
            {
                OdrzanaNastavaDodajVM model = new OdrzanaNastavaDodajVM
                {
                    Nastavnik = n.Ime + " " + n.Prezime,
                    NastavnikId=n.Id
                };

                LoadViewBag(id);
                return View(model);
            }
            return Redirect("/OdrzanaNastava/Index");
        }

        [HttpPost]
        public IActionResult Dodaj(OdrzanaNastavaDodajVM model)
        {
            PredajePredmet p = db.PredajePredmet.Find(model.PredajePredmetId);
            if (p != null)
            {

                OdrzanCas novi = new OdrzanCas
                {
                    DatumOdrzanogCasa = model.DatumOdrzanogCasa,
                    OdjeljenjeId=p.OdjeljenjeID,
                    PredajePredmetId=model.PredajePredmetId
                };
                db.Add(novi);
                db.SaveChanges();

                List<OdjeljenjeStavka> stavke = db.OdjeljenjeStavka.Where(d => d.OdjeljenjeId == p.OdjeljenjeID).ToList();

                foreach (var item in stavke)
                {
                    db.Add(new OdrzanCasDetalj
                    {
                        OdjeljenjeStavkaId=item.Id,
                        OdrzanCasId=novi.Id,
                        Prisutan=true
                    });
                    db.SaveChanges();
                }

                return Redirect("/OdrzanaNastava/Detalji/" + model.NastavnikId);
            }

            LoadViewBag(model.NastavnikId);
            return View(model);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            OdrzanCas o = db.OdrzanCas.Where(x => x.Id == id).Include(d => d.PredajePredmet).ThenInclude(d => d.Odjeljenje).Include(d => d.PredajePredmet.Predmet).SingleOrDefault();
            if (o != null)
            {
                OdrzanaNastavaEditVM model = new OdrzanaNastavaEditVM
                {
                    DatumOdrzanogCasa=o.DatumOdrzanogCasa,
                    Odjeljenje=o.PredajePredmet.Odjeljenje.Oznaka+" "+o.PredajePredmet.Predmet.Naziv,
                    SadrzajCasa=o.SadrzajCasa,
                    OdrzanCasId=o.Id
                };
                return View(model);
            }
            return Redirect("/OdrzanaNastava/Index");

        }

        [HttpPost]
        public IActionResult Edit(OdrzanaNastavaEditVM model)
        {
            OdrzanCas o = db.OdrzanCas.Where(x => x.Id == model.OdrzanCasId).Include(x => x.PredajePredmet).SingleOrDefault();
            if (o != null)
            {
                o.SadrzajCasa = model.SadrzajCasa;
                db.Update(o);
                db.SaveChanges();

            }
             return Redirect("/OdrzanaNastava/Index");
        }

        private void LoadViewBag(int id)
        {
            List<PredajePredmet> predmeti = db.PredajePredmet.Where(x => x.NastavnikID == id).Include(x=>x.Odjeljenje).Include(x=>x.Predmet).ToList();
            List<SelectListItem> comboPredmeti = new List<SelectListItem>();

            foreach (var item in predmeti)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.Odjeljenje.Oznaka + " / " + item.Predmet.Naziv;
                comboPredmeti.Add(x);
            }
            ViewBag.predmeti = comboPredmeti;
        }
    }
}