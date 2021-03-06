﻿// <auto-generated />
using System;
using EntityFrameworkExercise.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkExercise.Migrations
{
    [DbContext(typeof(MojDbContext))]
    partial class MojDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkExercise.Model.Fakultet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("fakulteti");
                });

            modelBuilder.Entity("EntityFrameworkExercise.Model.Opstina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("opstine");
                });

            modelBuilder.Entity("EntityFrameworkExercise.Model.Predmet", b =>
                {
                    b.Property<int>("PredmetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ects")
                        .HasColumnType("int");

                    b.HasKey("PredmetID");

                    b.ToTable("predmeti");
                });

            modelBuilder.Entity("EntityFrameworkExercise.Model.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("FakultetID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpstinaPrebivalistaID")
                        .HasColumnType("int");

                    b.Property<int>("OpstinaRodjenjaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FakultetID");

                    b.HasIndex("OpstinaPrebivalistaID");

                    b.HasIndex("OpstinaRodjenjaID");

                    b.ToTable("studenti");
                });

            modelBuilder.Entity("EntityFrameworkExercise.Model.UpisGodine", b =>
                {
                    b.Property<int>("UpisGodineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumUpisa")
                        .HasColumnType("datetime2");

                    b.Property<int>("GodinaStudija")
                        .HasColumnType("int");

                    b.Property<bool>("JelObnova")
                        .HasColumnType("bit");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("UpisGodineID");

                    b.HasIndex("StudentID");

                    b.ToTable("upisiGodina");
                });

            modelBuilder.Entity("EntityFrameworkExercise.Model.UpisaniPredmet", b =>
                {
                    b.Property<int>("UpisaniPredmetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DatumIspita")
                        .HasColumnType("datetime2");

                    b.Property<int>("PredmetID")
                        .HasColumnType("int");

                    b.Property<int>("UpisGodineID")
                        .HasColumnType("int");

                    b.Property<int?>("ZakljucnaOcjena")
                        .HasColumnType("int");

                    b.HasKey("UpisaniPredmetID");

                    b.HasIndex("PredmetID");

                    b.HasIndex("UpisGodineID");

                    b.ToTable("upisaniPredmeti");
                });

            modelBuilder.Entity("EntityFrameworkExercise.Model.Student", b =>
                {
                    b.HasOne("EntityFrameworkExercise.Model.Fakultet", "Fakultet")
                        .WithMany()
                        .HasForeignKey("FakultetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkExercise.Model.Opstina", "OpstinaPrebivalista")
                        .WithMany()
                        .HasForeignKey("OpstinaPrebivalistaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkExercise.Model.Opstina", "OpstinaRodjenja")
                        .WithMany()
                        .HasForeignKey("OpstinaRodjenjaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkExercise.Model.UpisGodine", b =>
                {
                    b.HasOne("EntityFrameworkExercise.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkExercise.Model.UpisaniPredmet", b =>
                {
                    b.HasOne("EntityFrameworkExercise.Model.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkExercise.Model.UpisGodine", "UpisGodine")
                        .WithMany()
                        .HasForeignKey("UpisGodineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
