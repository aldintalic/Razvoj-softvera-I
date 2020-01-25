using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1.Ispit.Web.Models;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class UputnicaController : Controller
    {
        private readonly MojContext db;

        public UputnicaController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<UputnicaIndexVM> model = db.Uputnica.Select(x => new UputnicaIndexVM
            {
                Uputio=x.DatumUputnice.ToShortDateString() +" | "+x.UputioLjekar.Ime,
                DatumEvidentiranja=x.DatumRezultata.ToString(),
                Pacijent=x.Pacijent.Ime,
                UputnicaId=x.Id,
                VrstaPretrage=x.VrstaPretrage.Naziv
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
        public IActionResult Dodaj(UputnicaDodajVM model)
        {
            if (ModelState.IsValid)
            {
                Uputnica nova = new Uputnica
                {
                    DatumUputnice=model.DatumUputnice,
                    IsGotovNalaz=false,
                    UputioLjekarId=model.LjekarId,
                    PacijentId=model.PacijentId,
                    VrstaPretrageId=model.VrstaPretrageId,
                };

                db.Add(nova);
                db.SaveChanges();

                List<LabPretraga> pretrage = db.LabPretraga.Where(x => x.VrstaPretrageId == model.VrstaPretrageId).ToList();
                foreach (var item in pretrage)
                {
                    db.Add(new RezultatPretrage
                    {
                        LabPretragaId = item.Id,
                        UputnicaId = nova.Id
                    });
                    db.SaveChanges();
                }
                return Redirect("Index");
            }

            LoadViewBag();
            return View(model);
        }

        public IActionResult Detalji(int id)
        {
            Uputnica u = db.Uputnica.Where(x=>x.Id==id).Include(x=>x.Pacijent).SingleOrDefault();
            if (u != null)
            {
                UputnicaDetaljiVM model = new UputnicaDetaljiVM
                {
                    DatumRezultata=u.DatumRezultata??default(DateTime),
                    DatumUputnice=u.DatumUputnice,
                    Pacijent=u.Pacijent.Ime,
                    UputnicaId=id
                };
                return View(model);
            }
            return Redirect("Index");


        }

        public IActionResult Zakljucaj(int id)
        {
            Uputnica u = db.Uputnica.Find(id);
            if (u != null && !u.IsGotovNalaz)
            {
                u.IsGotovNalaz = true;
                u.DatumRezultata = DateTime.Now;
                db.Update(u);
                db.SaveChanges();
                return Redirect("/Uputnica/Detalji/" + id);
            }
            return Redirect("/Uputnica");
        }

        private void LoadViewBag()
        {
            List<Ljekar> ljekari = db.Ljekar.ToList();
            List<SelectListItem> ljekariCombo = new List<SelectListItem>();

            foreach (var item in ljekari)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.Ime;
                ljekariCombo.Add(x);
            }

            List<VrstaPretrage> vrste = db.VrstaPretrage.ToList();
            List<SelectListItem> vrsteCombo = new List<SelectListItem>();

            foreach (var item in vrste)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.Naziv;
                vrsteCombo.Add(x);
            }

            List<Pacijent> pacijenti = db.Pacijent.ToList();
            List<SelectListItem> pacijentiCombo = new List<SelectListItem>();

            foreach (var item in pacijenti)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.Ime;
                pacijentiCombo.Add(x);
            }

            ViewBag.ljekari = ljekariCombo;
            ViewBag.vrste = vrsteCombo;
            ViewBag.pacijenti = pacijentiCombo;
        }
    }
}