using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenCodeAlong.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ExamenCodeAlong.Data
{
    public class EhelpBContext : IdentityDbContext<IdentityUser>
    {
        public EhelpBContext(DbContextOptions<EhelpBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vestiging>()
                .HasData(
                new Vestiging { Id = 1, Naam = "Antwerpen" },
                new Vestiging { Id = 2, Naam = "Brussel" },
                new Vestiging { Id = 3, Naam = "Gent" },
                new Vestiging { Id = 4, Naam = "Hasselt" },
                new Vestiging { Id = 5, Naam = "Leuven" });

            modelBuilder.Entity<Personeelslid>()
                .HasData(new Personeelslid { Id = 1, Username = "wim", Voornaam = "Wim", Achternaam = "Hambrouck", Wachtwoord = "admin", WachtwoordControle = "admin", VestigingId = 1 },
                new Personeelslid { Id = 2, Username = "jan", Voornaam = "Jan", Achternaam = "Janssens", Wachtwoord = "admin", WachtwoordControle = "admin", VestigingId = 1 },
                new Personeelslid { Id = 3, Username = "piet", Voornaam = "Piet", Achternaam = "Pieters", Wachtwoord = "admin", WachtwoordControle = "admin", VestigingId = 2 },
                new Personeelslid { Id = 4, Username = "jef", Voornaam = "Jef", Achternaam = "Jefsen", Wachtwoord = "admin", WachtwoordControle = "admin", VestigingId = 4 },
                new Personeelslid { Id = 5, Username = "karel", Voornaam = "Karel", Achternaam = "Karelsen", Wachtwoord = "admin", WachtwoordControle = "admin", VestigingId = 5 }
                );

            modelBuilder.Entity<Project>()
                .HasData(new Project { ProjectNaam = "PROJ_1234", HuidigBudget = 10000, Status = Status.AANGEMAAKT },
                new Project { ProjectNaam = "PROJ_2345", HuidigBudget = 20000, Status = Status.OPSTART });

            modelBuilder.Entity<PersoneelslidProject>().HasData(
                new PersoneelslidProject { Id = 1, PersoneelslidId = 1, ProjectId = "PROJ_1234" },
                new PersoneelslidProject { Id = 2, PersoneelslidId = 2, ProjectId = "PROJ_1234" },
                new PersoneelslidProject { Id = 3, PersoneelslidId = 3, ProjectId = "PROJ_1234" }
                );

        }

        public DbSet<Personeelslid> Personeelsleden { get; set; } = default!;
        public DbSet<Project> Projecten { get; set; } = default!;
        public DbSet<Vestiging> Vestigingen { get; set; } = default!;
        public DbSet<PersoneelslidProject> PersoneelslidProject { get; set; } = default!;
    }
}
