using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Models
{
    public class Commande
    {
        [Key]
        public  int Id { get; set;}
        public string Status { get; set; }
        //[ForeignKey("IdProd")]
        //public int IdProd { get; set; }
        //public List<Produit> produits { get; set; }
    }
}
