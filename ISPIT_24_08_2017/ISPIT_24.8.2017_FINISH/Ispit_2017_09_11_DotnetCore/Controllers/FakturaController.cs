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

namespace Ispit_2017_09_11_DotnetCore.Controllers
{

    public class FakturaController : Controller
    {
        private readonly MojContext db;

        public FakturaController(MojContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<FakturaIndexVM> model = db.Faktura.Select(x => new FakturaIndexVM
            {
                Datum = x.Datum.ToShortDateString(),
                Klijent = x.Klijent.ImePrezime,
                FakturaId = x.Id
            }).ToList();


            return View(model);
        }

        [HttpGet]
        public IActionResult Dodaj()
        {

            LoadViewBag();
            return View();
        }

        [HttpPost]
        public IActionResult Dodaj(FakturaDodajVM model)
        {
            Faktura nova = new Faktura
            {
                Datum = model.Datum,
                KlijentID = model.KlijentId
            };
            db.Add(nova);
            db.SaveChanges();

            if (model.PonudaId != 0)
            {
                List<PonudaStavka> stavke = db.PonudaStavka.Where(x => x.PonudaId == model.PonudaId).ToList();
                foreach (var item in stavke)
                {
                    db.Add(new FakturaStavka
                    {
                        Kolicina = item.Kolicina,
                        ProizvodID = item.ProizvodId,
                        PopustProcenat = (float)0.05,
                        FakturaID = nova.Id
                    });
                    db.SaveChanges();
                }
            }

            return Redirect("Index");

        }

        public IActionResult Detalji(int id)
        {
            Faktura f = db.Faktura.Where(x=>x.Id==id).Include(d=>d.Klijent).SingleOrDefault();
            if (f != null)
            {

                //List<FakturaDetaljiVM> model = db.FakturaStavka.Where(x => x.FakturaID == id)
                //                    .Select(x => new FakturaDetaljiVM
                //                    {
                //                        Cijena=x.Prozivod.Cijena,
                //                        FakturaId=f.Id,
                //                        Kolicina=x.Kolicina,
                //                        Popust=x.PopustProcenat,
                //                        Proizvod=x.Prozivod.Naziv
                //                    }).ToList();

                FakturaDetaljiVM model = new FakturaDetaljiVM
                {
                    FakturaId = f.Id,
                    Datum = f.Datum.ToShortDateString(),
                    Klijent = f.Klijent.ImePrezime
                };

                return View(model);
            }
            return Redirect("Index");
        }

        public IActionResult Obrisi(int id)
        {
            Faktura f = db.Faktura.Find(id);
            if (f != null)
            {
                db.Remove(f);
                db.SaveChanges();
            }
            return Redirect("/Faktura/Index");

        }
        private void LoadViewBag()
        {
            List<Ponuda> ponude = db.Ponuda.Where(x => x.FakturaID == null).Include(x => x.Klijent).ToList();
            List<SelectListItem> comboPonude = new List<SelectListItem>();

            foreach (var item in ponude)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.Klijent.ImePrezime + " - " + item.Datum.ToShortDateString();
                comboPonude.Add(x);
            }

            List<Klijent> klijenti = db.Klijent.ToList();
            List<SelectListItem> comboKlijenti = new List<SelectListItem>();

            foreach (var item in klijenti)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.ImePrezime;
                comboKlijenti.Add(x);
            }

            ViewBag.ponude = comboPonude;
            ViewBag.klijenti = comboKlijenti;

        }
    }
}