using EntityFrameworkExercise.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Globalization;
using EntityFrameworkExercise.Model.ViewsModels;
using EntityFrameworkExercise.ViewsModels;

namespace EntityFrameworkExercise
{
    class Program
    {
        public static MojDbContext Db = new MojDbContext();
        static string crt="\n-----------------------------------------\n";
        public static int OdaberiFakultetByID()
        {
            int izbor=-1;
            List<Fakultet> f = Db.fakulteti.ToList();
            

            foreach (Fakultet x in Db.fakulteti)
            {
                Console.WriteLine(x.ID + " : " + x.Naziv);
            }
            Console.WriteLine((f.Count() +1 )+ " : " + "Drugo");
            izbor = int.Parse(Console.ReadLine());

            if (izbor == f.Count+1)
                return -1;

            return izbor;

        }
        public static int OdaberiOpstinuByID()
        {
            int izbor=-1;
            List<Opstina> o = Db.opstine.ToList();


            foreach (Opstina x in Db.opstine)
            {
                Console.WriteLine(x.ID + " : " + x.Naziv);
            }
            Console.WriteLine((o.Count() + 1) + " : " + "Drugo");

            izbor = int.Parse(Console.ReadLine());

            if (izbor == o.Count+1)
                return -1;
            return izbor;

        }
        public static int PrikaziMeni()
        {
            int input;
            do
            {
                    
                Console.WriteLine(crt);
                Console.WriteLine("\t  FIT DB v1.0");
                Console.WriteLine(crt);
                Console.WriteLine(" 1.Dodaj fakultet");
                Console.WriteLine(" 2.Ispisi fakultete");
                Console.WriteLine(" 3.Dodaj opstinu");
                Console.WriteLine(" 4.Ispisi opstine");
                Console.WriteLine(" 5.Dodaj studenta");
                Console.WriteLine(" 6.Ispisi studente");
                Console.WriteLine(" 7.Prikazi fakultete sa brojem studenata");
                Console.WriteLine(" 8.Upis godine studija");
                Console.WriteLine(" 9.Studenti sa zadnjom upisanom godinom studija");
                Console.WriteLine(" 10.Evidentiraj zakljucne ocjene");

                Console.WriteLine(" 11.EXIT");
                Console.WriteLine(crt);
                input = int.Parse(Console.ReadLine());

            } while (input < 1 && input > 11);

            return input;
        }
        public static void DodajFakultet()
        {
            Fakultet x = new Fakultet();
            Console.WriteLine("Unesite naziv fakulteta: ");
            x.Naziv = Console.ReadLine();

            Db.fakulteti.Add(x);

            Db.SaveChanges();
        }
        public static void DodajOpstinu()
        {
            Opstina x = new Opstina();
            Console.WriteLine("Unesite naziv opstine: ");
            x.Naziv = Console.ReadLine();

            Db.opstine.Add(x);

            Db.SaveChanges();
        }
        public static void DodajStudenta()
        {
            Student x = new Student();
            Console.WriteLine("Unesite ime: ");
            x.Ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime: ");
            x.Prezime = Console.ReadLine();
            Console.WriteLine("Unesite datum rodjenja: ");
            x.DatumRodjenja = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Odaberi opstinu rodjenja: ");
            int opstinaRodjenjaID = OdaberiOpstinuByID();
            if (opstinaRodjenjaID==-1)
            {
                x.OpstinaRodjenja = new Opstina();
                Console.WriteLine("Unesite naziv opstine rodjenja: ");
                x.OpstinaRodjenja.Naziv = Console.ReadLine();
            }
            else
                x.OpstinaRodjenjaID = opstinaRodjenjaID;
            
            Console.WriteLine("Odaberi opstinu prebivalista: ");
            int opstinaPrebivalistaID = OdaberiOpstinuByID();
            if (opstinaPrebivalistaID==-1)
            {
                x.OpstinaPrebivalista = new Opstina();
                Console.WriteLine("Unesite naziv opstine prebivalista: ");
                x.OpstinaPrebivalista.Naziv = Console.ReadLine();
            }
            else
                x.OpstinaPrebivalistaID = opstinaPrebivalistaID;

            Console.WriteLine("Odaberi fakultet: ");
            int fakultetID = OdaberiFakultetByID();
            if (fakultetID==-1)
            {
                //DodajFakultet();
                //List<Fakultet> ff = db.fakulteti.ToList();
                //x.Fakultet= ff[ff.Count() - 1];
                x.Fakultet = new Fakultet();
                Console.WriteLine("Unesite naziv fakulteta:  ");
                x.Fakultet.Naziv = Console.ReadLine();
            }
            else
                x.FakultetID = fakultetID;

            Db.studenti.Add(x);

            Db.SaveChanges();

        }
        public static void PrikaziFakultete()
        {
            Console.WriteLine(crt);
            Console.WriteLine("FAKULTETI");
            Console.WriteLine(crt);
            foreach (Fakultet item in Db.fakulteti)
                Console.WriteLine(item.ID + " : " + item.Naziv);
        }
        public static void PrikaziOpstine()
        {
            Console.WriteLine(crt);
            Console.WriteLine("OPSTINE");
            Console.WriteLine(crt);
            foreach (Opstina item in Db.opstine)
                Console.WriteLine(item.ID + " : " + item.Naziv);
        }
        public static void PrikaziStudente()
        {
            List<Student> studenti = Db.studenti.Include(s => s.OpstinaPrebivalista).
                                               Include(s => s.OpstinaRodjenja).
                                               Include(s => s.Fakultet).ToList();

            Console.WriteLine(crt);
            Console.WriteLine("STUDENTI");
            Console.WriteLine(crt);

            foreach (Student item in studenti)
            {
                Console.WriteLine("Ime: " + item.Ime);
                Console.WriteLine("Prezime: " + item.Prezime);
                Console.WriteLine("Datum rodjenja: " + item.DatumRodjenja);
                Console.WriteLine("Opstina rodjenja: " + item.OpstinaRodjenja.Naziv);
                Console.WriteLine("Opstina prebivalista: " + item.OpstinaPrebivalista.Naziv);
                Console.WriteLine("Fakultet: " + item.Fakultet.Naziv + "\n\n");
            }
        }
        public static void FakultetiSaBrojemStudenata()
        {
            List<FakultetiBrStudenataVM> fbs = Db.fakulteti.Select(f => new FakultetiBrStudenataVM
            {
                FakultetID = f.ID,
                FakultetNaziv = f.Naziv,
                BrojStudenata = Db.studenti.Count(s => s.FakultetID == f.ID)

            }).ToList();

            
            Console.WriteLine(crt+"Naziv fakulteta\t| BrojStudenata"+crt);

            foreach (FakultetiBrStudenataVM x in fbs)
                Console.WriteLine(x.FakultetNaziv + " ---------> " + x.BrojStudenata+crt);


        }
        public static void UpisiGodinu()
        {
            foreach (Student s in Db.studenti)
                Console.WriteLine(s.ID + " : " + s.Ime + " " + s.Prezime);

            UpisGodine nova=new UpisGodine();
            
            Console.WriteLine("Izaberite studenta: ");
            int StudentId = int.Parse(Console.ReadLine());
            nova.StudentID = StudentId;

            Console.WriteLine("Godina studija: ");
            nova.GodinaStudija = int.Parse(Console.ReadLine());
            nova.DatumUpisa=DateTime.Now;

            UpisGodine zadnja = Db.upisiGodina.Where(u => u.StudentID == StudentId).OrderByDescending(d => d.DatumUpisa)
                .FirstOrDefault();
            if (zadnja != null && zadnja.GodinaStudija == nova.GodinaStudija)
                nova.JelObnova = true;
            else
                nova.JelObnova = false;

            Db.Add(nova);
            Db.SaveChanges();

        }
        public static void StudentiSaZadnjomUpisanomGodinom()
        {
            List<StudentZadnjaGodinaVM> studenti = Db.studenti.Select(s => new StudentZadnjaGodinaVM
            {
                StudentID = s.ID,
                Ime = s.Ime,
                Prezime = s.Prezime,
                GodinaStudija = Db.upisiGodina.Where(u=>u.StudentID==s.ID).OrderByDescending(d=>d.DatumUpisa).FirstOrDefault(),
                SumaECTS=Db.upisaniPredmeti.Where(u=>u.UpisGodine.StudentID==s.ID).Where(u=>u.ZakljucnaOcjena>0).Sum(e=>e.Predmet.ects)
            }).ToList();

            Console.WriteLine(crt+"Ime i prezime studenta\t Zadnji upis godine\tECTS"+crt);

            foreach (StudentZadnjaGodinaVM s in studenti)
            {
                Console.Write(s.Ime + " " + s.Prezime + " ");
                if (s.GodinaStudija != null)
                {
                    Console.WriteLine(@s.GodinaStudija.GodinaStudija + " godina - " + s.GodinaStudija.DatumUpisa +
                                      ((s.GodinaStudija.JelObnova) ? " (obnova godine) " : " ") + s.SumaECTS + crt);
                }
            }

        }
        public static void EvidentirajZakljucneOcjene()
        {
            foreach (Student s in Db.studenti)
                Console.WriteLine(s.ID + " : " + s.Ime + " " + s.Prezime);
            
            int studentID = int.Parse(Console.ReadLine());

            UpisGodine zadnjiUpis = Db.upisiGodina.Where(s => s.StudentID == studentID).OrderByDescending(s => s.DatumUpisa).
                                        FirstOrDefault();

            if (zadnjiUpis == null)
            {
                Console.WriteLine("Student nije aktivan, ne moze se evidentirati ocjena.");
                return;
            }

            List<UpisaniPredmet> predmeti = Db.upisaniPredmeti.Where(p => p.UpisGodineID == zadnjiUpis.UpisGodineID).Include(x => x.Predmet).ToList();

            foreach (UpisaniPredmet up in predmeti)
            {
                Console.WriteLine(up.Predmet.Naziv + " " + up.ZakljucnaOcjena);
                if(up.ZakljucnaOcjena==null || up.ZakljucnaOcjena == 0)
                {
                    Console.WriteLine("Unesite ocjenu: ");
                    up.ZakljucnaOcjena = int.Parse(Console.ReadLine());
                    up.DatumIspita = DateTime.Now;
                }
            }

            Db.SaveChanges();

        }


        static void Main(string[] args)
        { 
            int input;

            do
            {
                input = PrikaziMeni();

                if (input == 1)
                    DodajFakultet();

                if (input == 2)
                    PrikaziFakultete();

                if (input == 3)
                    DodajOpstinu();

                if (input == 4)
                    PrikaziOpstine();

                if (input == 5)
                    DodajStudenta();

                if (input == 6)
                    PrikaziStudente();

                if (input == 7)
                    FakultetiSaBrojemStudenata();
                
                if (input == 8)
                    UpisiGodinu();

                if (input == 9)
                    StudentiSaZadnjomUpisanomGodinom();

                if (input == 10)
                    EvidentirajZakljucneOcjene();


                System.Threading.Thread.Sleep(4000);
                Console.Clear();

            } while (input!=11);

            Console.WriteLine("DOVIDJENJA :)");
            
            Db.Dispose();
        }

        
    }
}
