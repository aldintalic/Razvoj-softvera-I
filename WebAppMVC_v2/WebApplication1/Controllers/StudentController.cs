using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using ClassLibrary1.ViewsModels;
using EntityFrameworkExercise.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkExercise.Model.ViewsModels;
using EntityFrameworkExercise.ViewsModels;
using ClassLibrary1.ViewsModels.Student;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //PRVI NACIN
        //public IActionResult PrikaziStudente()
        //{
        //    MojDbContext db = new MojDbContext();

        //    List<Student> studenti = db.studenti.Include(s => s.OpstinaPrebivalista).
        //        Include(s => s.OpstinaRodjenja).
        //        Include(s => s.Fakultet).ToList();

        //    //ViewData["StudentiKey"] = studenti;
        //    db.Dispose();

        //    return View(studenti);
        //}

        //DRUGI NACIN
        public IActionResult PrikaziStudente()
        {
            MojDbContext db = new MojDbContext();

            List<StudentiPrikaziVM> studenti = db.studenti.Select(s => new StudentiPrikaziVM
            {
                ID = s.ID,
                Ime = s.Ime,
                Prezime = s.Prezime,
                Ects = db.upisaniPredmeti.Where(up => up.UpisGodine.StudentID == s.ID && up.ZakljucnaOcjena > 5).Sum(up => up.Predmet.ects)
            }).ToList();

            db.Dispose();

            return View(studenti);
        }

        public ActionResult Dodaj(string Ime, string Prezime, DateTime DatumRodjenja, int OpstinaRodjenjaID, int OpstinaPrebivalistaID,
            int FakultetID)
        {
            MojDbContext db=new MojDbContext();

            Student novi=new Student();
            novi.Ime = Ime;
            novi.Prezime = Prezime;
            novi.DatumRodjenja = DatumRodjenja;
            novi.OpstinaRodjenjaID = OpstinaRodjenjaID;
            novi.OpstinaPrebivalistaID= OpstinaPrebivalistaID;
            novi.FakultetID = FakultetID;

            db.Add(novi);
            db.SaveChanges();
            db.Dispose();

            return Redirect("PrikaziPoruku");
        }

        public ActionResult PrikaziPoruku()
        {
            return View("PrikaziPoruku");
        }

        //PRVI NACIN
        //public ActionResult DodajStudentaForma()
        //{
        //    MojDbContext db=new MojDbContext();

        //    List<Fakultet> fakulteti = db.fakulteti.ToList();
        //    List<Opstina> opstine = db.opstine.ToList();

        //    ViewData["FakultetiKey"] = fakulteti;
        //    ViewData["OpstineKey"] = opstine;
        //    db.Dispose();

        //    return View("DodajStudentaForma");
        //}

        //DRUGI NACIN
        public ActionResult DodajStudentaForma()
        {
            MojDbContext db = new MojDbContext();

            List<ComboBoxVM> fakulteti = db.fakulteti.Select(f => new ComboBoxVM
            {
                ID = f.ID,
                Opis = f.Naziv
            }).ToList();

            List<ComboBoxVM> opstine = db.opstine.Select(o => new ComboBoxVM
            {
                ID = o.ID,
                Opis = o.Naziv
            }).ToList();

            ViewData["fakultetiKey"] = fakulteti;
            ViewData["opstineKey"] = opstine;

            db.Dispose();

            return View();
        }

        public ActionResult ObrisiStudenta(int id)
        {
            MojDbContext db=new MojDbContext();
            Student s = db.studenti.Find(id);
            db.studenti.Remove(s);
            db.SaveChanges();
            db.Dispose();

            return Redirect("/Student/PrikaziStudente");
        }
    }
}