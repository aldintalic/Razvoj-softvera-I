using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
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
            List<IspitiIndexVM> model = db.Angazovan.Include(d => d.Nastavnik).Include(d => d.Predmet).Include(d => d.AkademskaGodina).Select(d => new IspitiIndexVM
            {
                AkademskaGodina = d.AkademskaGodina.Opis,
                AngazovanId = d.Id,
                ImeIPrezimeNastavnika = d.Nastavnik.Ime + " " + d.Nastavnik.Prezime,
                NazivPredmeta = d.Predmet.Naziv,
                BrojOdrzanihCasova = db.OdrzaniCas.Count(s => s.AngazovaniId == d.Id),
                BrojStudenataNaPredmetu = db.SlusaPredmet.Count(p => p.AngazovanId == d.Id)
            }).OrderBy(w => w.NazivPredmeta).ToList();


            return View(model);
        }

        public IActionResult Prikazi(int id)
        {
            Angazovan a = db.Angazovan.Where(d => d.Id == id).Include(d => d.Predmet).Include(d => d.AkademskaGodina).Include(d => d.Nastavnik).SingleOrDefault();

            if (a != null)
            {
                List<IspitiPrikaziVM> model = db.Ispit.Where(d => d.AngazovanId == id).Select(d => new IspitiPrikaziVM
                {
                    IspitId = d.IspitId,
                    DatumIspita = d.Datum.ToShortDateString(),
                    EvidentiraniRezultati = d.EvidentiraniRezultati == true ? "DA" : "NE",
                    BrojPrijavljenih = db.IspitStavka.Count(i => i.IspitId == d.IspitId),
                    BrojStudenataPolozili = db.IspitStavka.Count(i => i.IspitId == d.IspitId && i.Ocjena == 5)
                }).ToList();

                ViewBag.predmet = a.Predmet.Naziv;
                ViewBag.nastavnik = a.Nastavnik.Ime + " " + a.Nastavnik.Prezime;
                ViewBag.akademskagodina = a.AkademskaGodina.Opis;
                ViewBag.id = a.Id;
                return View(model);
            }

            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Dodaj(int id)
        {
            Angazovan a = db.Angazovan.Where(d => d.Id == id).Include(d => d.Predmet).Include(d => d.Nastavnik).Include(d => d.AkademskaGodina).SingleOrDefault();
            if (a != null)
            {
                IspitiDodajVM model = new IspitiDodajVM
                {
                    AngazovanId=a.Id,
                    Nastavnik=a.Nastavnik.Ime+" "+a.Nastavnik.Prezime,
                    Predmet=a.Predmet.Naziv,
                    SkolskaGodina=a.AkademskaGodina.Opis
                };
                return View(model);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Dodaj(IspitiDodajVM model)
        {
            Angazovan a = db.Angazovan.Find(model.AngazovanId);
            if (a != null)
            {
                Ispit novi = new Ispit
                {
                    AngazovanId=model.AngazovanId,
                    Datum=model.Datum,
                    Napomena=model.Napomena
                };
                db.Add(novi);
                db.SaveChanges();

                List<SlusaPredmet> stavke = db.SlusaPredmet.Where(d => d.AngazovanId == model.AngazovanId).ToList();
                foreach (var item in stavke)
                {
                    IspitStavka i = new IspitStavka
                    {
                        IspitId=novi.IspitId,
                        UpisGodineId=item.UpisGodineId,
                        Pristupio=false
                    };

                    db.Add(i);
                    db.SaveChanges();
                }

                return Redirect("/Ispiti/Prikazi/" + model.AngazovanId);
            }
            return Redirect("Index");
        }

        public IActionResult Detalji(int id)
        {
            Ispit i = db.Ispit.Where(d => d.IspitId == id).Include(d => d.Angazovan).ThenInclude(d=>d.AkademskaGodina)
                                                          .Include(d => d.Angazovan).ThenInclude(d => d.Predmet)
                                                          .Include(d => d.Angazovan).ThenInclude(d => d.Nastavnik).SingleOrDefault();
            if (i != null)
            {
                IspitiDetaljiVM model = new IspitiDetaljiVM
                {
                    AkademskaGodina=i.Angazovan.AkademskaGodina.Opis,
                    Nastavnik=i.Angazovan.Nastavnik.Ime+" "+i.Angazovan.Nastavnik.Prezime,
                    Predmet=i.Angazovan.Predmet.Naziv,
                    ispitId=i.IspitId,
                    Datum=i.Datum.ToShortDateString(),
                    Napomena=i.Napomena,
                    Zakljucano=i.EvidentiraniRezultati==true?true:false
                };
                return View(model);
            }
            return Redirect("Index");
        }

        public IActionResult Zakljucaj(int id)
        {
            Ispit i = db.Ispit.Find(id);
            if (i != null)
            {
                if (i.EvidentiraniRezultati==null || i.EvidentiraniRezultati==false)
                {
                    i.EvidentiraniRezultati = true;
                    db.Update(i);
                    db.SaveChanges();
                }
                return Redirect("/Ispiti/Prikazi/" + i.AngazovanId);
            }
            return Redirect("Index");
        }

        public IActionResult Pristupio(int id)
        {
            IspitStavka stavka = db.IspitStavka.Where(d => d.Id == id).Include(d => d.Ispit).SingleOrDefault();

            if (stavka != null)
            {
                if (stavka.Ispit.EvidentiraniRezultati==null || stavka.Ispit.EvidentiraniRezultati==false)
                {
                    if (stavka.Pristupio)
                        stavka.Pristupio = false;
                    else
                        stavka.Pristupio = true;
                    db.Update(stavka);
                    db.SaveChanges();
                }
                return Redirect("/Ispiti/Detalji/" + stavka.IspitId);
            }
            return Redirect("Index");

        }
    }
}