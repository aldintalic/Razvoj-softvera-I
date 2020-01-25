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

        public IActionResult Detalji(int id)
        {
            List<AjaxDetaljiVM> model = db.FakturaStavka.Where(x => x.FakturaID == id)
                                .Select(x => new AjaxDetaljiVM
                                {
                                    Cijena = x.Prozivod.Cijena,
                                    FakturaId = id,
                                    Kolicina = x.Kolicina,
                                    Popust = x.PopustProcenat,
                                    Proizvod = x.Prozivod.Naziv,
                                    StavkaId = x.Id
                                }).ToList();

            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Uredi(int id)
        {
            FakturaStavka stavka = db.FakturaStavka.Find(id);
            if (stavka != null)
            {
                AjaxTestUrediVM model = new AjaxTestUrediVM
                {
                    Kolicina = stavka.Kolicina,
                    StavkaId = stavka.Id,
                    ProizvodId = stavka.ProizvodID,
                };

                LoadViewBag();
                return PartialView(model);
            }

            return Redirect("/AjaxTest/Detalji/" + stavka.FakturaID);
        }

        [HttpPost]
        public IActionResult Uredi(AjaxTestUrediVM model)
        {
            FakturaStavka stavka = db.FakturaStavka.Find(model.StavkaId);

            stavka.Kolicina = model.Kolicina;
            stavka.ProizvodID = model.ProizvodId;
            db.Update(stavka);
            db.SaveChanges();

            return Redirect("/AjaxTest/Detalji/" + stavka.FakturaID);
        }

        public IActionResult Obrisi(int id)
        {
            FakturaStavka stavka = db.FakturaStavka.Find(id);
            int fakturaId = stavka.FakturaID;
            if (stavka != null)
            {
                db.Remove(stavka);
                db.SaveChanges();
            }
            return Redirect("/AjaxTest/Detalji/" +fakturaId);

        }

        private void LoadViewBag()
        {
            List<Proizvod> proizvodi = db.Proizvod.ToList();
            List<SelectListItem> comboProizvod = new List<SelectListItem>();

            foreach (var item in proizvodi)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.Naziv;
                comboProizvod.Add(x);
            }
            ViewBag.proizvodi = comboProizvod;

        }
    }
}