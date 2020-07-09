using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GestionFacturation.Api.Models
{

    public class Produit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Categorie Categorie { get; set; }

        public Stock Stock { get; set; }

        public byte[] Image { get; set; }
    }
}