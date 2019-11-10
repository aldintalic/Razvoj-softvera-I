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

        public ActionResult DodajZapis(string NazivFakulteta, int UniverzitetID )
        {
            //ovdje dodati kod za dodavanje zapisa u tabelu
            MojDbContext Db = new MojDbContext();
            if (NazivFakulteta != null)
            {

                Fakultet novi = new Fakultet();

                novi.Naziv = NazivFakulteta;
                novi.UniverzitetID = UniverzitetID;

                Db.fakulteti.Add(novi);
                Db.SaveChanges();

                return Redirect("/fakultet/DodajPoruku");
            }
            Db.Dispose();
            return Redirect("/fakultet/opcija8html");
        }

        public ActionResult DodajPoruku()
        {
            return View("DodajPoruku");
        }

        public ActionResult DodajForma()
        {
            MojDbContext Db = new MojDbContext();
            List<ComboBoxVM> univerziteti = Db.univerziteti.Select(u => new ComboBoxVM
            {
                ID = u.ID,
                Opis = u.Naziv
            }).ToList();

            ViewData["univerzitetiKey"] = univerziteti;
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
            return Redirect("/Fakultet/opcija8html");
        }
    }
}
