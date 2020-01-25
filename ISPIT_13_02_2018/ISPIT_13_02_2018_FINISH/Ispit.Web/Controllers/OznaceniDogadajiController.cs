using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Web.Helper;
using Ispit.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Ispit.Data;
using Ispit.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Ispit.Web.ViewModels;

namespace Ispit.Web.Controllers
{
    [Autorizacija]
    public class OznaceniDogadajiController : Controller
    {
        private readonly MyContext db;

        public OznaceniDogadajiController(MyContext db)
        {
            this.db = db;
        }


        public IActionResult Index()
        {
            int logiraniKorisnik = HttpContext.GetLogiraniKorisnik().Id;

            List<OznaceniDogadajiPrikazVM> model = db.Dogadjaj.Select(x => new OznaceniDogadajiPrikazVM
            {
                DatumDogadjaja = x.DatumOdrzavanja,
                Nastavnik = x.Nastavnik.ImePrezime,
                BrojObaveza = db.Obaveza.Count(ob => ob.DogadjajID == x.ID),
                OpisDogadjaja = x.Opis,
                DogadjajId = x.ID,
                KorisnikId = logiraniKorisnik
            }).ToList();

            foreach (var item in model)
            {
                OznacenDogadjaj od = db.OznacenDogadjaj.Where(x => x.DogadjajID == item.DogadjajId && x.StudentID == logiraniKorisnik).SingleOrDefault();

                if (od != null)
                {
                    item.OznacenDogadjaj = true;
                    item.IzvrsenoProcentualno = db.StanjeObaveze.Where(d => d.OznacenDogadjajID == od.ID).Sum(s => s.IzvrsenoProcentualno) / item.BrojObaveza;
                }
            }
            GetNotifikacije(db.Student.Where(s => s.KorisnickiNalogId == logiraniKorisnik).Single().ID);
            return View(model);
        }

        public IActionResult Dodaj(int DogadjajId, int KorisnikId)
        {
            Dogadjaj d = db.Dogadjaj.Find(DogadjajId);
            Student s = db.Student.Where(x => x.KorisnickiNalogId == KorisnikId).SingleOrDefault();
            if (d != null && s != null)
            {
                OznacenDogadjaj novi = new OznacenDogadjaj
                {
                    DatumDodavanja = DateTime.Now,
                    DogadjajID = DogadjajId,
                    StudentID = s.ID
                };

                db.Add(novi);
                db.SaveChanges();

                List<Obaveza> obaveze = db.Obaveza.Where(o => o.DogadjajID == d.ID).ToList();

                foreach (var item in obaveze)
                {
                    StanjeObaveze stanjeObaveze = new StanjeObaveze
                    {
                        DatumIzvrsenja = DateTime.Parse("1/1/2020"),
                        IsZavrseno = false,
                        IzvrsenoProcentualno = 0,
                        NotifikacijaDanaPrije = item.NotifikacijaDanaPrijeDefault,
                        NotifikacijeRekurizivno = item.NotifikacijeRekurizivnoDefault,
                        ObavezaID = item.ID,
                        OznacenDogadjajID = novi.ID
                    };
                    db.Add(stanjeObaveze);
                    db.SaveChanges();
                }
            }

            return Redirect("Index");
        }

        public IActionResult Detalji(int id)
        {
            OznacenDogadjaj d = db.OznacenDogadjaj
                                .Where(x => x.DogadjajID == id)
                                .Include(p => p.Dogadjaj)
                                .ThenInclude(n => n.Nastavnik)
                                .SingleOrDefault();

            if (d != null)
            {

                OznaceniDogadajiDetaljiVM model = new OznaceniDogadajiDetaljiVM
                {
                    DatumDodavanja = d.DatumDodavanja,
                    DatumDogadjaja = d.Dogadjaj.DatumOdrzavanja,
                    Nastavnik = d.Dogadjaj.Nastavnik.ImePrezime,
                    OpisDogadjaja = d.Dogadjaj.Opis,
                    DogadjajId = id
                };

                return View(model);
            }
            return View("Greska");
        }

        public IActionResult ProcitanaNotifikacija(int id)
        {
            StanjeObaveze s = db.StanjeObaveze.Find(id);
            if (s != null)
            {
                s.IsZavrseno = true;
                db.SaveChanges();
            }
            return Redirect("/OznaceniDogadaji/Index");
        }
        private void GetNotifikacije(int studentId)
        {
            List<OznacenDogadjaj> lista = db.OznacenDogadjaj.Where(x => x.StudentID == studentId).ToList();
            List<OznaceniDogadajiNotifikacijeVM> notifikacije = new List<OznaceniDogadajiNotifikacijeVM>();
            foreach (var item in lista)
            {
                List<StanjeObaveze> s = db.StanjeObaveze
                            .Where(d => d.OznacenDogadjajID == item.ID)
                            .Include(d => d.Obaveza)
                            .Include(d => d.OznacenDogadjaj)
                            .ThenInclude(d => d.Dogadjaj)
                            .ToList();
                foreach (var st in s)
                {

                    if ((st.OznacenDogadjaj.Dogadjaj.DatumOdrzavanja - DateTime.Now).TotalDays <= st.NotifikacijaDanaPrije)
                    {
                        notifikacije.Add(new OznaceniDogadajiNotifikacijeVM
                        {
                            Dogadjaj = st.OznacenDogadjaj.Dogadjaj.Opis,
                            Datum = st.OznacenDogadjaj.Dogadjaj.DatumOdrzavanja,
                            Obaveza = st.Obaveza.Naziv,
                            Rekurzivno = st.NotifikacijeRekurizivno ? true : false,
                            Procitana = st.IsZavrseno,
                            StanjeId=st.Id
                        });
                    }

                    else
                    {
                        st.IsZavrseno = true;
                        db.SaveChanges();
                    }
                }
            }
            ViewBag.notifikacije = notifikacije;
        }

    }
}