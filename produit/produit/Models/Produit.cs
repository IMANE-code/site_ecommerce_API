using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Models
{
    public class Produit
    {
        [Key]
        public int Id { get; set; }
        public string NameProduit { get; set; }
        public float PrixProduit { get; set; }
        
    }
}
