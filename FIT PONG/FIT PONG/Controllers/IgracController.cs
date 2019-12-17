﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FIT_PONG.Models;
using FIT_PONG.ViewModels.IgracVMs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FIT_PONG.Controllers
{
    public class IgracController : Controller
    {
        private static int BROJAC { get; set; } = 0; //sluzi samo pri generisanju imena usera i logina...

        private readonly MyDb db;
        private readonly IWebHostEnvironment _host;

        public IgracController(MyDb context, IWebHostEnvironment host)
        {
            db = context;
            _host = host;
        }

        public IActionResult Index(string searchBy, string search, string orderBy)
        {
            if (search == null)
                ViewData["prazno"] = "nema igraca";
            if (searchBy == "JacaRuka")
            {
                List<IgracVM> igraci = db.Igraci.Select(x => new IgracVM
                {
                    ID = x.ID,
                    BrojPosjetaNaProfil = x.BrojPosjetaNaProfil,
                    JacaRuka = x.JacaRuka,
                    PrikaznoIme = x.PrikaznoIme,
                    ProfileImagePath = x.ProfileImagePath,
                    Visina = x.Visina,
                    ELO = x.ELO
                }).Where(x => x.JacaRuka == search || search == null).ToList();
                igraci=Sort(igraci, orderBy);
                return View(igraci);
            }
            else
            {
                List<IgracVM> igraci = db.Igraci.Select(x => new IgracVM
                {
                    ID = x.ID,
                    BrojPosjetaNaProfil = x.BrojPosjetaNaProfil,
                    JacaRuka = x.JacaRuka,
                    PrikaznoIme = x.PrikaznoIme,
                    ProfileImagePath = x.ProfileImagePath,
                    Visina = x.Visina,
                    ELO = x.ELO
                }).Where(x => x.PrikaznoIme.Contains(search) || search == null).OrderBy(x => x.PrikaznoIme).ToList();
                igraci=Sort(igraci, orderBy);
                return View(igraci);
            }
            
        }

        public IActionResult PrikazProfila(int id)
        {
            Igrac objIgrac = db.Igraci.SingleOrDefault(x => x.ID == id);
            if (objIgrac == null)
                return View("Greska");
            IgracVM igrac = new IgracVM(objIgrac);
            igrac.statistika = db.Statistike.Where(s => s.IgracID == id && s.AkademskaGodina==DateTime.Now.Year).SingleOrDefault();
            igrac.BrojPostovanja=db.Postovanja.Count(p => p.PostovaniID == id);
            return View(igrac);
        }
        
        [HttpPost]
        public IActionResult Dodaj(IgracDodajVM igrac)
        {
            if (ModelState.IsValid)
            {
                if (igrac.PrikaznoIme!=null && !JeLiUnique(igrac.PrikaznoIme))
                {
                    ModelState.AddModelError(nameof(igrac.PrikaznoIme), "Prikazno ime je zauzeto.");
                    return View(igrac);
                }
                int id=KreirajLoginIUsera();
                Igrac novi = new Igrac
                {
                    ID = id,
                    BrojPosjetaNaProfil = 0,
                    ELO = 1000,
                    JacaRuka = igrac.JacaRuka,
                    PrikaznoIme = igrac.PrikaznoIme,
                    Visina = igrac.Visina
                };
                Statistika statistika = new Statistika(novi.ID);

                if (igrac.Slika!=null){
                    if (!igrac.Slika.ContentType.Contains("image"))
                    {
                        ModelState.AddModelError(nameof(igrac.Slika), "Mozete uploadat samo sliku.");
                    }
                    else
                    {
                        string ImeFajla = ProcesSpremanjaSlike(igrac);
                        novi.ProfileImagePath = "~/igraci/"+ImeFajla;
                    }
                }
                else
                {
                    novi.ProfileImagePath = "/profile_picture_default.png";
                }
                db.Add(novi);
                db.Add(statistika);
                db.SaveChanges();
                return Redirect("/Igrac/PrikazProfila/"+novi.ID);
            }

            return View(igrac);

        }

        [HttpGet]
        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditPodatke(int igracID)
        {
            Igrac igrac = db.Igraci.Find(igracID);

            if (igrac == null)
            {
                return View("Greska");
            }
            IgracEditPodatkeVM obj = new IgracEditPodatkeVM
            {
                ID = igrac.ID,
                JacaRuka = igrac.JacaRuka,
                PrikaznoIme = igrac.PrikaznoIme,
                Visina = igrac.Visina,
                ProfileImagePath=igrac.ProfileImagePath
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult EditPodatke(IgracEditPodatkeVM obj)
        {
            Igrac igrac = db.Igraci.Find(obj.ID);
            
            if (igrac!=null && ModelState.IsValid)
            {
                if (obj.PrikaznoIme!=igrac.PrikaznoIme && !JeLiUnique(obj.PrikaznoIme))
                {
                    ModelState.AddModelError(nameof(obj.PrikaznoIme), "Prikazno ime je zauzeto.");
                    return View(obj);
                }

                igrac.JacaRuka = obj.JacaRuka;
                igrac.Visina= obj.Visina;
                igrac.PrikaznoIme = obj.PrikaznoIme;
                db.Update(igrac);
                db.SaveChanges();

                return Redirect("/Igrac/PrikazProfila/" + igrac.ID);
            }
            return View(obj);
        }

        public IActionResult UkloniSliku(int igracID)
        {
            Igrac obj = db.Igraci.Find(igracID);
            if (obj == null)
            {
                return View("Greska");
            }
            if (obj.ProfileImagePath != "/profile_picture_default.png")
            {
                ProcesBrisanjaSlike(obj.ProfileImagePath);
                obj.ProfileImagePath = "/profile_picture_default.png";
                db.SaveChanges();
            }
            return Redirect("/Igrac/PrikazProfila/" + igracID);

        }

        [HttpGet]
        public IActionResult EditSliku(int igracID)
        {
            Igrac igrac = db.Igraci.Find(igracID);

            if (igrac == null)
                return View("Greska");
            
            IgracEditSlikuVM obj = new IgracEditSlikuVM
            {
                ID = igracID,
                ExistingProfileImagePath=igrac.ProfileImagePath,
                JacaRuka=igrac.JacaRuka,
                BrojPosjetaNaProfil=igrac.BrojPosjetaNaProfil,
                ELO=igrac.ELO,
                PrikaznoIme=igrac.PrikaznoIme,
                Visina=igrac.Visina
            };

            return View(obj);
        }

        [HttpPost]
        public IActionResult EditSliku(IgracEditSlikuVM obj)
        {
            Igrac igrac = db.Igraci.Find(obj.ID);
            if (igrac != null)
            {
                if (obj.Slika != null)
                {
                    if (!obj.Slika.ContentType.Contains("image"))
                    {
                        ModelState.AddModelError(nameof(obj.Slika), "Mozete uploadat samo sliku.");
                        return View(obj);
                    }
                    else
                    {
                        if (obj.ExistingProfileImagePath != null && obj.ExistingProfileImagePath!="/profile_picture_default.png")
                            ProcesBrisanjaSlike(obj.ExistingProfileImagePath);
                        igrac.ProfileImagePath= "~/igraci/" + ProcesSpremanjaSlike(obj);
                    }
                }
                
                db.Update(igrac);
                db.SaveChanges();
                return Redirect("/Igrac/PrikazProfila/" + obj.ID);
            }
            return View("Greska");

        }

        public IActionResult Statistike(int igracID)
        {
            List<Statistika> stats = db.Statistike.Where(s => s.IgracID == igracID).OrderByDescending(s => s.AkademskaGodina).ToList();
            ViewBag.statistike = stats;
            Igrac i = db.Igraci.Find(igracID);
            if (i == null)
                return View("Greska");
            ViewBag.igrac = i.PrikaznoIme;
            return View();
        }

        public IActionResult PostujIgraca(int postivalacID, int postovaniID)
        {
            Igrac igrac2 = db.Igraci.Find(postivalacID);
            Igrac igrac1 = db.Igraci.Find(postovaniID);
            if (igrac1 == null || igrac2 == null)
                return View("Greska");
            Postovanje novo = new Postovanje(postivalacID, postovaniID);
            db.Add(novo);
            db.SaveChanges();
            return Redirect("/Igrac/PrikazProfila/" + postovaniID);

        }
        private string ProcesSpremanjaSlike(IgracDodajVM obj)
        {
            string ImeFajla = null;
            if (obj != null)
            {
                Directory.CreateDirectory(Path.Combine(_host.WebRootPath, "igraci").ToString());
                ImeFajla = Guid.NewGuid().ToString() + "_" + obj.PrikaznoIme + obj.Slika.FileName.Substring(obj.Slika.FileName.IndexOf("."));
                string PathSpremanja = Path.Combine(_host.WebRootPath, "igraci", ImeFajla);
                using (var fileStream = new FileStream(PathSpremanja, FileMode.Create)) 
                {
                    obj.Slika.CopyTo(fileStream);
                }
            }
            return ImeFajla;
        }

        private void ProcesBrisanjaSlike(string putanja)
        {
            string filePutanja = Path.Combine(_host.WebRootPath, putanja.Substring(putanja.IndexOf("/") + 1));
            System.IO.File.Delete(filePutanja);
        } 

        private List<IgracVM> Sort(List<IgracVM> igraci, string sortBy)
        {
            switch (sortBy)
            {
                case "PrikaznoIme":
                    return igraci.OrderBy(x => x.PrikaznoIme).ToList();
                case "EloRaiting":
                    return igraci = igraci.OrderByDescending(x => x.ELO).ToList();
                case "BrojPosjetaNaProfil":
                    return igraci = igraci.OrderByDescending(x => x.BrojPosjetaNaProfil).ToList();
                default:
                    return igraci;
            }

        }
        private bool JeLiUnique(string username)
        {
            List<Igrac> igraci = db.Igraci.ToList();
            foreach (var item in igraci)
            {
                if (item.PrikaznoIme == username)
                    return false;
            }
            return true;
        }


        //funkcija sluzi za generisanje usera i logina koji su potrebni da bi se kreirao igrac,
        //jer igrac preuzima id od usera, a u user posjeduje loginID, tako da je to dvoje neophodno
        //ovo je naravno samo privremeno, dok se ne rijesi microsoft identity
        //samo je tu zbog testiranja funkcionalnosti
        private int KreirajLoginIUsera()
        {
            Login l = new Login
            {
                Username = "Username " + BROJAC,
                PasswordHash = "PasswordHash " + BROJAC,
                PasswordSalt = "PasswordSalt " + BROJAC
            };
            db.Add(l);
            db.SaveChanges();
            User u = new User
            {
                Ime = "Ime - " + BROJAC,
                Prezime = "Prezime " + BROJAC,
                DatumRodjenja = DateTime.Now,
                Email = $"ime{BROJAC}.prezime{BROJAC}@edu.fit.ba",
                LoginID = l.ID,
                GradID = 20
            };
            db.Add(u);
            db.SaveChanges();
            BROJAC++;
            return u.ID;
        }

    }
}