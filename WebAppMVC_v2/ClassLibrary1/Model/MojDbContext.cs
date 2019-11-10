using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1.Model;

namespace EntityFrameworkExercise.Model
{
    public class MojDbContext:DbContext
    {

        public DbSet<Student> studenti { get; set; }
        public DbSet<Fakultet> fakulteti { get; set; }
        public DbSet<Opstina> opstine { get; set; }
        public DbSet<UpisGodine> upisiGodina { get; set; }
        public DbSet<Predmet> predmeti { get; set; }
        public DbSet<UpisaniPredmet> upisaniPredmeti { get; set; }
        public DbSet<Univerzitet> univerziteti { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local)\MSSQLSERVER_OLAP;
                                          Database=Studenti_EF_v2;
                                          Trusted_Connection=True;
                                          MultipleActiveResultSets=True;");

        }
    }
}
