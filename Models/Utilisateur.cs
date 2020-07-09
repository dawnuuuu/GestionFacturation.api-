using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionFacturation.Api.Models
{
    public class Utilisateur
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string UserName { get; set; }
        public string Telephone { get; set; }
        
        public string Adresse { get; set; }
        public string Type { get; set; }
        //[JsonIgnore]
        public string Password { get; set; }






    }
}
