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

        public ActionResult Detalji(int id)
        {
            List<AjaxTestDetalji> model = db.OdjeljenjeStavka
                                        .Where(d => d.OdjeljenjeId == id)
                                        .Select(x => new AjaxTestDetalji
                                        {
                                            Id = x.UcenikId,
                                            BrojUDnevniku = x.BrojUDnevniku,
                                            Ucenik = x.Ucenik.ImePrezime,
                                            BrojZakljucnihOcjena = db.DodjeljenPredmet
                                                      .Where(c => c.OdjeljenjeStavka.OdjeljenjeId == id && c.OdjeljenjeStavka.UcenikId==x.UcenikId)
                                                      .Count(z=>z.ZakljucnoKrajGodine>1)
                                        }).OrderBy(u=>u.BrojUDnevniku).ToList();
            ViewBag.id = id;
  
            return PartialView(model);
        }
    
        [HttpGet]
        public ActionResult Dodaj(int id)
        {
            Odjeljenje o = db.Odjeljenje.Find(id);

            if (o != null)
            {
                LoadViewBag(id);
                return PartialView();
            }
            return Redirect("/Odjeljenje/Detalji/" + id);
        }
    
        [HttpPost]
        public ActionResult Dodaj(AjaxTestDodajVM model)
        {
                if (model.BrojUDnevniku > 0)
                {
                    OdjeljenjeStavka nova = new OdjeljenjeStavka
                    {
                        BrojUDnevniku = model.BrojUDnevniku,
                        OdjeljenjeId = model.OdjeljenjeId,
                        UcenikId = model.UcenikID
                    };
                    
                    db.OdjeljenjeStavka.Add(nova);
                    db.SaveChanges();
                    return Redirect("/AjaxTest/Detalji/"+ model.OdjeljenjeId);
                }

            return View(model);

        }

        public ActionResult Greska()
        {
            return PartialView();
        }

        private void LoadViewBag(int id)
        {
            List<SelectListItem> ucenici = new List<SelectListItem>();
            foreach (var item in db.OdjeljenjeStavka.Include(d => d.Ucenik).Where(x => x.OdjeljenjeId != id).ToList())
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.UcenikId.ToString();
                x.Text = item.Ucenik.ImePrezime;
                ucenici.Add(x);
            }
            ViewBag.ucenici = ucenici;

            List<SelectListItem> slobodniBrojevi = new List<SelectListItem>();
            List<int> pomocna = new List<int>();
            
            //foreach (var item in db.OdjeljenjeStavka.Where(x => x.OdjeljenjeId != id).ToList())
            //{
            //    SelectListItem x = new SelectListItem();
            //    x.Value = item.BrojUDnevniku.ToString();
            //    x.Text = item.BrojUDnevniku.ToString();
            //    if (!pomocna.Contains(item.BrojUDnevniku))
            //    {
            //        pomocna.Add(item.BrojUDnevniku);
            //        slobodniBrojevi.Add(x);
            //    }
            //    br = item.BrojUDnevniku;
            //}
            //while (pomocna.Count()<100)
            //{
            //        pomocna.Add(br);
            //        slobodniBrojevi.Add(new SelectListItem { Value = br.ToString(), Text = br.ToString() });
            //        br++;
            //}
            
            ViewBag.slobodniBrojevi = slobodniBrojevi;
            ViewBag.id = id;
        }
    }
}