using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using ClassLibrary1.ViewsModels;
using EntityFrameworkExercise.Model;
using EntityFrameworkExercise.Model.ViewsModels;
using EntityFrameworkExercise;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApplication1.Controllers
{
    public class FakultetController:Controller
    {

        public ActionResult Index()
        {
            return View("Index");
        }


        public string Opcija1()
        {
            return "Hello. Danas je " + DateTime.Now.ToString("dddd") + "!";
        }

        public List<FakultetiBrStudenataVM> Opcija8Json()
        {
            MojDbContext Db = new MojDbContext();

            List<FakultetiBrStudenataVM> fbs = Db.fakulteti.Select(f => new FakultetiBrStudenataVM
            {
                FakultetID = f.ID,
                FakultetNaziv = f.Naziv,
                BrojStudenata = Db.studenti.Count(s => s.FakultetID == f.ID)

            }).ToList();
            
            Db.Dispose();
            return fbs;
        }

        public ActionResult Opcija8html()
        {
            return View("Opcija8View");
        }

        public ActionResult DodajZapis(int fakultetID, string NazivFakulteta, int UniverzitetID )
        {
            //ovdje dodati kod za dodavanje zapisa u tabelu
            MojDbContext Db = new MojDbContext();

            Fakultet f;

            if (fakultetID == 0)
            {
                f = new Fakultet();
                Db.fakulteti.Add(f);
            }
            else
            {
                f = Db.fakulteti.Find(fakultetID);
            }

            f.Naziv = NazivFakulteta;
            f.UniverzitetID = UniverzitetID;

            Db.SaveChanges();
            Db.Dispose();

            return Redirect("/fakultet/DodajPoruku");   
        }

        public ActionResult DodajPoruku()
        {
            return View("DodajPoruku");
        }

        public ActionResult DodajForma(int fakultetID)
        {
            MojDbContext Db = new MojDbContext();

            Fakultet f = new Fakultet();

            if (fakultetID != 0)
            {
                f = Db.fakulteti.Find(fakultetID);
            }
            
            TempData["fakultetiKey"] = f;
            List<ComboBoxVM> univerziteti = Db.univerziteti.Select(u => new ComboBoxVM
            {
                ID = u.ID,
                Opis = u.Naziv
            }).ToList();
            TempData["univerzitetiKey"] = univerziteti;

            Db.Dispose();

            return View("DodajForma");
        }

        public ActionResult ObrisiZapis(int id)
        {
            MojDbContext db=new MojDbContext();
            Fakultet f=db.fakulteti.Find(id);
            db.fakulteti.Remove(f);
            db.SaveChanges();
            db.Dispose();
            TempData["nekiKey"] = f.Naziv;
            return Redirect("/Fakultet/ObrisiPoruka");
        }

        public ActionResult ObrisiPoruka()
        {
            return View();
        }
    }
}
