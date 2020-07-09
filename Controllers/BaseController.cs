using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionFacturation.Api.Auth;
using GestionFacturation.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionFacturation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = Roles.Admin)]
    public class BaseController<T> : Controller where T : class
    {

        private readonly ILogger<BaseController<T>> _logger;

        private readonly ApplicationDbContext _context;

        public BaseController(ILogger<BaseController<T>> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        //[HttpGet]
        //public virtual IEnumerable<T> Get() => _context.Set<T>();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        //[HttpPost]
        //public virtual ActionResult<T> PostItem(T item)
        //{

        //    var itm = _context.Add(item).Entity;

        //    _context.SaveChanges();

        //    return itm;
        //} 

        
        [HttpPost]
        public virtual async Task <ActionResult<T>> PostItemAsync(T item)
        {
            var itm = _context.Add(item).Entity;

            await _context.SaveChangesAsync();

            return itm;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetObeject(Guid id)
        {
            var item = await _context.Set<T>().FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }


        //public void Put(int id, [FromBody] Employee employee)
        //{
        //    using (EmployeeDBContext dbContext = new EmployeeDBContext())
        //    {
        //        var entity = dbContext.Employees.FirstOrDefault(e => e.ID == id);
        //        entity.FirstName = employee.FirstName;
        //        entity.LastName = employee.LastName;
        //        entity.Gender = employee.Gender;
        //        entity.Salary = employee.Salary;
        //        dbContext.SaveChanges();
        //    }
        //}


        [HttpPut]
        public async Task<IActionResult> PutObject(T item)
        {

            Type type = item.GetType();

            if (type == typeof(Client))
            {
                var entity = _context.Clients.FirstOrDefault(e => e.Id ==   (Guid)type.GetProperty("Id").GetValue(item));

                Client itm = item as Client;

                if (itm == null) return NotFound();

                entity.Adresse = itm.Adresse;
                entity.CodePostal = itm.CodePostal;
                entity.Email = itm.Email;
                entity.Telephone = itm.Telephone;
                entity.Nom = itm.Nom;
                entity.Prenom = itm.Prenom;
                entity.Ville = itm.Ville;

                

            }
            else if(type==typeof(Article))
            {
                var entity = _context.Articles.FirstOrDefault(e => e.Id == (Guid)type.GetProperty("Id").GetValue(item));

                Article itm = item as Article;

                if (itm == null) return NotFound();

                entity.Nom = itm.Nom;
                entity.Designation = itm.Designation;
                entity.PrixHT = itm.PrixHT;
                entity.PrixTTC = itm.PrixTTC;
                entity.Quantite = itm.Quantite;
                entity.TVA = itm.TVA;


            }
            else if (type == typeof(Categorie))
            {
                var entity = _context.Categories.FirstOrDefault(e => e.Id == (Guid)type.GetProperty("Id").GetValue(item));

                Categorie itm = item as Categorie;

                if (itm == null) return NotFound();

                entity.Nom = itm.Nom;
                entity.Code = itm.Code;

            }
            else if (type == typeof(Devis))
            {
                var entity = _context.Deviss.FirstOrDefault(e => e.Id == (Guid)type.GetProperty("Id").GetValue(item));

                Devis itm = item as Devis;

                if (itm == null) return NotFound();

                entity.Article = itm.Article;
                entity.Client = itm.Client;
                entity.DateLivaraison = itm.DateLivaraison;
                entity.PrixTotal = itm.PrixTotal;

            }
            else if (type == typeof(Facture))
            {

                var entity = _context.Factures.FirstOrDefault(e => e.Id == (Guid)type.GetProperty("Id").GetValue(item));

                Facture itm = item as Facture;

                if (itm == null) return NotFound();

                entity.Client = itm.Client;
                entity.DateEcheance = itm.DateEcheance;
                entity.DateGeneration = itm.DateGeneration;
                entity.Devis = itm.Devis;
                entity.Paiement = itm.Paiement;
                entity.Statut = itm.Statut;

            }
            else if (type == typeof(Paiement))
            {

                var entity = _context.Paiements.FirstOrDefault(e => e.Id == (Guid)type.GetProperty("Id").GetValue(item));

                Paiement itm = item as Paiement;

                if (itm == null) return NotFound();

                entity.PrixTTC = itm.PrixTTC;
                entity.StatutFacture = itm.StatutFacture;

            }
            else if (type == typeof(Produit))
            {

                var entity = _context.Produits.FirstOrDefault(e => e.Id == (Guid)type.GetProperty("Id").GetValue(item));

                Produit itm = item as Produit;

                if (itm == null) return NotFound();

                entity.Categorie = itm.Categorie;
                entity.Image = itm.Image;
                entity.Stock = itm.Stock;

            }
            else if (type == typeof(Stock))
            {
                var entity = _context.Stocks.FirstOrDefault(e => e.Id == (Guid)type.GetProperty("Id").GetValue(item));

                Stock itm = item as Stock;

                if (itm == null) return NotFound();

                entity.Quantite = itm.Quantite;

            }
            else if (type == typeof(Utilisateur))
            {
                var entity = _context.Utilisateurs.FirstOrDefault(e => e.Id == (Guid)type.GetProperty("Id").GetValue(item));

                Utilisateur itm = item as Utilisateur;

                if (itm == null) return NotFound();

                entity.Adresse = itm.Adresse;
                entity.Nom = itm.Nom;
                entity.Telephone = itm.Adresse;
                entity.Prenom = itm.Prenom;
                entity.Password = itm.Password;
                entity.Type = itm.Type;
                entity.UserName = itm.UserName;

            }

            var saved= await _context.SaveChangesAsync();

            return saved>0 ? (IActionResult) Ok() : NoContent();
        }


        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> DeleteObject(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    
    }
}
