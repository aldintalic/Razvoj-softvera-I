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
            Uputnica u = db.Uputnica.Find(id);
            
            if (u != null) {
                //List<AjaxTestDetaljiVM> model = db.RezultatPretrage.Where(x => x.UputnicaId == id).Select(d => new AjaxTestDetaljiVM
                //{
                //    Pretraga = d.LabPretraga.Naziv,
                //    IzmjerenaVrijednost = d.LabPretraga.VrstaVr == VrstaVrijednosti.Modalitet ? d.Modalitet.Opis : d.NumerickaVrijednost.ToString(),
                //    JMJ = d.LabPretraga.MjernaJedinica,
                //    RezultatId = d.Id,
                //    IsZavrsen = d.Uputnica.IsGotovNalaz,
                //    ReferentnaVrijednostMax = db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().LabPretraga != null ?
                //    db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().LabPretraga.ReferentnaVrijednostMax : 0.0,
                //    ReferentnaVrijednostMin = db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().LabPretraga != null ?
                //    db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().LabPretraga.ReferentnaVrijednostMin : 0.0,
                //    Vrsta = db.RezultatPretrage.Where(w => w.UputnicaId == id && w.LabPretragaId == d.LabPretragaId).Include(w => w.LabPretraga).SingleOrDefault().LabPretraga.VrstaVr.ToString(),
                //    ReferentnaVrijednostMod = db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().Modalitet != null ?
                //    db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().Modalitet.IsReferentnaVrijednost : false,
                //    Modaliteti=LoadViewBag(db.Modalitet.Where(x => x.LabPretragaId == d.LabPretragaId).ToList())
                //}).ToList();

                
                return PartialView(GetModel(id));
              }
            return PartialView("Greska");

        }

        [HttpGet]
        public IActionResult Uredi(int id)
        {
            RezultatPretrage r = db.RezultatPretrage.Where(c => c.Id == id).Include(d => d.LabPretraga).Include(d => d.Modalitet).SingleOrDefault();
            if (r != null)
            {
                AjaxTestUrediVM model = new AjaxTestUrediVM
                {
                    RezultatId = r.Id,
                    NumerickaVrijednost = r.NumerickaVrijednost,
                    Pretraga = r.LabPretraga.Naziv,
                    VrstaVr = r.LabPretraga.VrstaVr.ToString(),
                    ModalitetId=r.ModalitetId
                };
                if (model.VrstaVr == "Modalitet")
                    model.Vrijednost = r.Modalitet.Opis;

                LoadViewBag(db.Modalitet.Where(x => x.LabPretragaId == r.LabPretragaId).ToList());
                return PartialView(model);
            }
            return PartialView("Greska");
        }

        [HttpPost]
        public IActionResult Uredi(AjaxTestUrediVM model)
        {
            RezultatPretrage r = db.RezultatPretrage.Where(x => x.Id == model.RezultatId).Include(d=>d.LabPretraga).Include(d => d.Modalitet).SingleOrDefault();
            if (r != null)
            {
                if (r.LabPretraga.VrstaVr == VrstaVrijednosti.Modalitet)
                {
                    r.ModalitetId = model.ModalitetId;
                }
                else
                {
                    r.NumerickaVrijednost = model.NumerickaVrijednost;
                }
                db.Update(r);
                db.SaveChanges();
                return Redirect("/AjaxTest/Detalji/" + r.UputnicaId);
            }
            LoadViewBag(db.Modalitet.Where(x=>x.LabPretragaId==r.LabPretragaId).ToList());
            return PartialView(model);
        }

        public IActionResult UrediTabela(int id, string vrijednost)
        {
            RezultatPretrage r = db.RezultatPretrage.Where(x => x.Id == id).Include(x => x.LabPretraga).SingleOrDefault();
            if (r != null)
            {
                if (r.LabPretraga.VrstaVr == VrstaVrijednosti.Modalitet)
                    r.ModalitetId = int.Parse(vrijednost);
                else
                    r.NumerickaVrijednost = double.Parse(vrijednost);
                db.Update(r);
                db.SaveChanges();
            }
                return PartialView("~/Views/AjaxTest/Detalji.cshtml", GetModel(r.UputnicaId));
            
        }

        private List<SelectListItem> LoadViewBag(List<Modalitet> mod)
        {
            //List<Modalitet> mod = db.Modalitet.Where(x => x.LabPretragaId == id).ToList();
            List<SelectListItem> modCombo = new List<SelectListItem>();
            foreach (var item in mod)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.Id.ToString();
                x.Text = item.Opis;
                modCombo.Add(x);
            }
            ViewBag.modaliteti = modCombo;
            return modCombo;
        }

        private List<AjaxTestDetaljiVM> GetModel(int id)
        {
            List<AjaxTestDetaljiVM> model = db.RezultatPretrage.Where(x => x.UputnicaId == id).Select(d => new AjaxTestDetaljiVM
            {
                Pretraga = d.LabPretraga.Naziv,
                IzmjerenaVrijednost = d.LabPretraga.VrstaVr == VrstaVrijednosti.Modalitet ? d.Modalitet.Opis : d.NumerickaVrijednost.ToString(),
                JMJ = d.LabPretraga.MjernaJedinica,
                RezultatId = d.Id,
                IsZavrsen = d.Uputnica.IsGotovNalaz,
                ReferentnaVrijednostMax = db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().LabPretraga != null ?
                db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().LabPretraga.ReferentnaVrijednostMax : 0.0,
                ReferentnaVrijednostMin = db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().LabPretraga != null ?
                db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().LabPretraga.ReferentnaVrijednostMin : 0.0,
                Vrsta = db.RezultatPretrage.Where(w => w.UputnicaId == id && w.LabPretragaId == d.LabPretragaId).Include(w => w.LabPretraga).SingleOrDefault().LabPretraga.VrstaVr.ToString(),
                ReferentnaVrijednostMod = db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().Modalitet != null ?
                db.RezultatPretrage.Where(c => c.UputnicaId == id && c.LabPretragaId == d.LabPretragaId).Include(c => c.LabPretraga).SingleOrDefault().Modalitet.IsReferentnaVrijednost : false,
                Modaliteti = LoadViewBag(db.Modalitet.Where(x => x.LabPretragaId == d.LabPretragaId).ToList())
            }).ToList();

            return model;
        }
    }
}