using GestionFacturation.Api.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace GestionFacturation.Api.Models
{
    public class ApplicationDbContext : IdentityDbContext<User<Guid>, Roles<Guid>, Guid>
    {

        public DbSet<Article> Articles { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Devis> Deviss { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<User> Users { get; set; }
        



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=GestionFacturationDB.db");
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Client>().ToTable("Clients");
        //    modelBuilder.Entity<Devis>().ToTable("Deviss");
        //    modelBuilder.Entity<Facture>().ToTable("Factures");
        //    modelBuilder.Entity<Paiement>().ToTable("Paiements");
        //    modelBuilder.Entity<Produit>().ToTable("Produits");
        //    modelBuilder.Entity<Utilisateur>().ToTable("Utilisateurs");
        //}


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Devis>()
        //        .HasMany(c => c.Article);
           

        //}

        public void InitDb()
        {
            using var context = new ApplicationDbContext();

            context.Clients.AddRange(new Client[]
            {
                new Client()
                {
                    Prenom = "Khtatba",
                    Nom = "Doha",
                    Ville = "Tanger",
                    Adresse = "Complexe El Fajr A imm 4 no 98 Tanger",
                    Telephone = "0638253210",
                    CodePostal = 90000,
                    Email = "khtatbadoha@gmail.com"
                },

                new Client()
                {
                    Prenom = "Ballouti",
                    Nom = "Ouissal",
                    Ville = "Ksar Kbir",
                    Adresse = "Idrissia",
                    Telephone = "01746226673",
                    CodePostal = 9000,
                    Email = "ouissal1966@gmail.com"
                },

                

            });
            context.SaveChanges();


        }
    }
}

