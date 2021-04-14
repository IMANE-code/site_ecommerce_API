using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Models
{
    public class ListProduit
    {
        public int Id { get; set; }

        [ForeignKey("IdProduit,IdPanier")]
        public int IdProduit { get; set; }
        public int IdPanier { get; set; }

    }
}
