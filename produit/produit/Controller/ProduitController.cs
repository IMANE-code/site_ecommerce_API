using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Controller
{
    public class ProduitController : ControllerBase
    {
        public IActionResult Index()
        {
            return ViewResult();
        }

        private IActionResult ViewResult()
        {
            throw new NotImplementedException();
        }
    }
}
