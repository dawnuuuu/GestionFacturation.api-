using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionFacturation.Api.Models
{
    public class Stock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Quantite { get; set; }
    }
}