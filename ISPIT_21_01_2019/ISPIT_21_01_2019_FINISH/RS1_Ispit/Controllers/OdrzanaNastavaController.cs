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
            List<OdrzanaNastavaIndexVM> model = db.Nastavnik.Select(d => new OdrzanaNastavaIndexVM
            {
                ImeIPrezimeNastavnika = d.Ime + " " + d.Prezime,
                NastavnikId = d.Id,
                Skola = db.Odjeljenje.Where(x => x.RazrednikID == d.Id).Include(x => x.Skola).FirstOrDefault() != null ? db.Odjeljenje.Where(x => x.RazrednikID == d.Id).Include(x => x.Skola).FirstOrDefault().Skola.Naziv :
                " "
            }).ToList();


            return View(model);
        }

        public IActionResult PrikaziMaturskeIspite(int id)
        {
            Nastavnik n = db.Nastavnik.Find(id);
            if (n != null)
            {
                List<OdrzanaNastavaPrikaziMaturskeIspiteVM> model = db.MaturskiIspit
                                .Include(x => x.PredajePredmet).ThenInclude(x => x.Predmet)
                                .Include(x => x.PredajePredmet).ThenInclude(x => x.Odjeljenje).ThenInclude(x => x.Skola)
                                .Where(x => x.PredajePredmet.NastavnikID == id)
                                .Select(x => new OdrzanaNastavaPrikaziMaturskeIspiteVM
                                {
                                    Datum = x.DatumOdrzavanja.ToShortDateString(),
                                    MaturskiIspitId = x.Id,
                                    Predmet = x.PredajePredmet.Predmet.Naziv,
                                    Skola = x.PredajePredmet.Odjeljenje.Skola.Naziv,
                                    NisuPristupiliUcenici = db.MaturskiIspitStavka.Where(d => d.MaturskiIspitId == x.Id && d.RezultatIspita == null)
                                        .Include(d => d.OdjeljenjeStavka).ThenInclude(d => d.Ucenik)
                                        .Select(d => d.OdjeljenjeStavka.Ucenik.ImePrezime).ToList()

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
                    SkolskaGodina =DateTime.Now.Year.ToString()+"/"+(DateTime.Now.Year + 1).ToString().Substring(2)
                };
                LoadViewBag(id);

                return View(model);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Dodaj(OdrzanaNastavaDodajVM model)
        {
            PredajePredmet p = db.PredajePredmet.Find(model.PredajePredmetId);
            if (p != null)
            {
                MaturskiIspit novi = new MaturskiIspit
                {
                    DatumOdrzavanja = model.Datum,
                    PredajePredmetId = model.PredajePredmetId
                };
                db.Add(novi);
                db.SaveChanges();

                List<OdjeljenjeStavka> ucenici = db.OdjeljenjeStavka
                            .Include(x => x.Odjeljenje)
                            .Where(x => x.Odjeljenje.Razred == 4 && x.Odjeljenje.SkolaID == model.SkolaId).ToList();
                foreach (var item in ucenici)
                {
                    if (Provjera(item.Id))
                    {
                        MaturskiIspitStavka m = new MaturskiIspitStavka
                        {
                            MaturskiIspitId = novi.Id,
                            OdjeljenjeStavkaId = item.Id,
                        };
                        db.Add(m);
                        db.SaveChanges();
                    }
                }
                return Redirect("/OdrzanaNastava/PrikaziMaturskeIspite/" + p.NastavnikID);
            }
            
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Uredi(int id)
        {
            MaturskiIspit m = db.MaturskiIspit.Include(s => s.PredajePredmet).ThenInclude(s => s.Predmet).Where(d => d.Id == id).SingleOrDefault();
            if (m != null)
            {
                OdrzanaNastavaUrediVM model = new OdrzanaNastavaUrediVM
                {
                    Datum=m.DatumOdrzavanja.ToShortDateString(),
                    MaturskiIspitId=m.Id,
                    Napomena=m.Napomena,
                    Predmet=m.PredajePredmet.Predmet.Naziv
                };
                return View(model);
            }
            return Redirect("Index");

        }

        [HttpPost]
        public IActionResult Uredi(OdrzanaNastavaUrediVM model)
        {
            MaturskiIspit m = db.MaturskiIspit.Include(d => d.PredajePredmet).Where(d => d.Id == model.MaturskiIspitId).SingleOrDefault();

            if (m != null)
            {
                m.Napomena = model.Napomena;
                db.Update(m);
                db.SaveChanges();
                return Redirect("/OdrzanaNastava/PrikaziMaturskeIspite/" + m.PredajePredmet.NastavnikID);
            }
            return View(model);
        }


        private bool Provjera(int id)
        {
            foreach (var u in db.DodjeljenPredmet
                        .Include(d => d.OdjeljenjeStavka).ThenInclude(d => d.Odjeljenje)
                        .Where(d => d.OdjeljenjeStavkaId == id && d.OdjeljenjeStavka.Odjeljenje.Razred == 4).ToList())
            {
                if (u.ZakljucnoKrajGodine == 1)
                    return false;

            }
            MaturskiIspitStavka zadnji = db.MaturskiIspitStavka.Where(d => d.OdjeljenjeStavkaId == id).LastOrDefault();
            if (zadnji!=null && zadnji.RezultatIspita!=null && zadnji.RezultatIspita < 55)
                return true;
            return false;
        }

        private void LoadViewBag(int id)
        {
            List<PredajePredmet> predmeti = db.PredajePredmet.Include(d => d.Predmet).Include(d => d.Odjeljenje).ThenInclude(d => d.Skola).Where(d => d.NastavnikID == id).ToList();
            List<SelectListItem> comboPredmeti = new List<SelectListItem>();
            List<SelectListItem> comboSkole = new List<SelectListItem>();


            foreach (var item in predmeti)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.Predmet.Naziv;
                comboPredmeti.Add(x);

                SelectListItem y = new SelectListItem();
                y.Value = item.Odjeljenje.SkolaID.ToString();
                y.Text = item.Odjeljenje.Skola.Naziv.ToString();
                if (!comboSkole.Contains(y))
                    comboSkole.Add(y);

            }

            ViewBag.predmeti = comboPredmeti;
            ViewBag.skole = comboSkole;
        }
    }
}
