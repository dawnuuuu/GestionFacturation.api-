using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionFacturation.Api.Models
{

    public class Devis
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Client Client { get; set; }

        public IList<Article> Article { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateLivaraison { get; set; }

        public float PrixTotal { get; set; }
    }
}
