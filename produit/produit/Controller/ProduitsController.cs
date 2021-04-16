using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using produit.Models;
using produit.Repositorie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {

        private readonly IProduitRepository _produitRepository;

        public ProduitsController(IProduitRepository produitRepository)
        {
            _produitRepository = produitRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Produit>> GetProduits()
        {
            return await _produitRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produit>> GetProduits(int id)
        {
            return await _produitRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Produit>> PostProduits([FromBody] Produit produit)
        {
            var newProduit = await _produitRepository.Create(produit);
            return CreatedAtAction(nameof(GetProduits), new { id = newProduit.Id }, newProduit);
        }

        [HttpPut]
        public async Task<ActionResult<Produit>> PutProduits(int id, [FromBody] Produit produit)
        {
            if (id != produit.Id)
            {
                return BadRequest();
            }
            await _produitRepository.Update(produit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produit>> Delete(int id)
        {
            var produitToDelete = await _produitRepository.Get(id);
            if (produitToDelete == null)
                return NotFound();

            await _produitRepository.Delete(produitToDelete.Id);
            return NoContent();


        }

    }
}
