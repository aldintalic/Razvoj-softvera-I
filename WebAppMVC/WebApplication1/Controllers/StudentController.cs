using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExercise.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public IActionResult PrikaziStudente()
        {
            MojDbContext db = new MojDbContext();

            List<Student> studenti = db.studenti.Include(s => s.OpstinaPrebivalista).
                Include(s => s.OpstinaRodjenja).
                Include(s => s.Fakultet).ToList();

            //ViewData["StudentiKey"] = studenti;

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

            return Redirect("PrikaziPoruku");
        }

        public ActionResult PrikaziPoruku()
        {
            return View("PrikaziPoruku");
        }

        public ActionResult DodajStudentaForma()
        {
            MojDbContext db=new MojDbContext();

            List<Fakultet> fakulteti = db.fakulteti.ToList();
            List<Opstina> opstine = db.opstine.ToList();

            ViewData["FakultetiKey"] = fakulteti;
            ViewData["OpstineKey"] = opstine;


            return View("DodajStudentaForma");
        }

        public ActionResult ObrisiStudenta(int id)
        {
            MojDbContext db=new MojDbContext();
            Student s = db.studenti.Find(id);
            db.studenti.Remove(s);
            db.SaveChanges();
            return Redirect("/Student/PrikaziStudente");
        }
    }
}