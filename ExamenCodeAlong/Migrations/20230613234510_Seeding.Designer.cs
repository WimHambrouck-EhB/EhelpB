﻿// <auto-generated />
using ExamenCodeAlong.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamenCodeAlong.Migrations
{
    [DbContext(typeof(EhelpBContext))]
    [Migration("20230613234510_Seeding")]
    partial class Seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExamenCodeAlong.Models.Personeelslid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VestigingId")
                        .HasColumnType("int");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WachtwoordControle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VestigingId");

                    b.ToTable("Personeelsleden");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Achternaam = "Hambrouck",
                            Username = "wim",
                            VestigingId = 1,
                            Voornaam = "Wim",
                            Wachtwoord = "admin",
                            WachtwoordControle = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Achternaam = "Janssens",
                            Username = "jan",
                            VestigingId = 1,
                            Voornaam = "Jan",
                            Wachtwoord = "admin",
                            WachtwoordControle = "admin"
                        },
                        new
                        {
                            Id = 3,
                            Achternaam = "Pieters",
                            Username = "piet",
                            VestigingId = 2,
                            Voornaam = "Piet",
                            Wachtwoord = "admin",
                            WachtwoordControle = "admin"
                        },
                        new
                        {
                            Id = 4,
                            Achternaam = "Jefsen",
                            Username = "jef",
                            VestigingId = 4,
                            Voornaam = "Jef",
                            Wachtwoord = "admin",
                            WachtwoordControle = "admin"
                        },
                        new
                        {
                            Id = 5,
                            Achternaam = "Karelsen",
                            Username = "karel",
                            VestigingId = 5,
                            Voornaam = "Karel",
                            Wachtwoord = "admin",
                            WachtwoordControle = "admin"
                        });
                });

            modelBuilder.Entity("ExamenCodeAlong.Models.PersoneelslidProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PersoneelslidId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PersoneelslidId");

                    b.HasIndex("ProjectId");

                    b.ToTable("PersoneelslidProjecten");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PersoneelslidId = 1,
                            ProjectId = "PROJ_1234"
                        },
                        new
                        {
                            Id = 2,
                            PersoneelslidId = 2,
                            ProjectId = "PROJ_1234"
                        },
                        new
                        {
                            Id = 3,
                            PersoneelslidId = 3,
                            ProjectId = "PROJ_1234"
                        });
                });

            modelBuilder.Entity("ExamenCodeAlong.Models.Project", b =>
                {
                    b.Property<string>("ProjectNaam")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("HuidigBudget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ProjectNaam");

                    b.ToTable("Projecten");

                    b.HasData(
                        new
                        {
                            ProjectNaam = "PROJ_1234",
                            HuidigBudget = 10000m,
                            Status = 0
                        },
                        new
                        {
                            ProjectNaam = "PROJ_2345",
                            HuidigBudget = 20000m,
                            Status = 1
                        });
                });

            modelBuilder.Entity("ExamenCodeAlong.Models.Vestiging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vestigingen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naam = "Antwerpen"
                        },
                        new
                        {
                            Id = 2,
                            Naam = "Brussel"
                        },
                        new
                        {
                            Id = 3,
                            Naam = "Gent"
                        },
                        new
                        {
                            Id = 4,
                            Naam = "Hasselt"
                        },
                        new
                        {
                            Id = 5,
                            Naam = "Leuven"
                        });
                });

            modelBuilder.Entity("ExamenCodeAlong.Models.Personeelslid", b =>
                {
                    b.HasOne("ExamenCodeAlong.Models.Vestiging", "Vestiging")
                        .WithMany()
                        .HasForeignKey("VestigingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vestiging");
                });

            modelBuilder.Entity("ExamenCodeAlong.Models.PersoneelslidProject", b =>
                {
                    b.HasOne("ExamenCodeAlong.Models.Personeelslid", "Personeelslid")
                        .WithMany("PersoneelslidProjecten")
                        .HasForeignKey("PersoneelslidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamenCodeAlong.Models.Project", "Project")
                        .WithMany("PersoneelslidProjecten")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personeelslid");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ExamenCodeAlong.Models.Personeelslid", b =>
                {
                    b.Navigation("PersoneelslidProjecten");
                });

            modelBuilder.Entity("ExamenCodeAlong.Models.Project", b =>
                {
                    b.Navigation("PersoneelslidProjecten");
                });
#pragma warning restore 612, 618
        }
    }
}
