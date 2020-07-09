using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionFacturation.Api.Models
{
    public class Article
    {
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public float PrixTTC { get; set; }
        public float TVA { get; set; }
        public int Quantite { get; set; }
        public string Designation { get; set; }
        public float PrixHT { get; set; }

    }
}