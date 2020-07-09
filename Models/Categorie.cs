using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionFacturation.Api.Models
{
    public class Categorie
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public int Code { get; set; }
    }
}