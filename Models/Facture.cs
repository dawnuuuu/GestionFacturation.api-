using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionFacturation.Api.Models
{
    public class Facture
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Statut { get; set; }

        public Client Client { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateGeneration { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateEcheance { get; set; }

        public IList<Devis> Devis { get; set; }

        public Paiement Paiement { get; set; }

    }
}
