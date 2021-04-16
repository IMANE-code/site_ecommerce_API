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
    public class CatégoriesController : ControllerBase
    {

        private readonly ICatégorieRepository _catégorieRepository ;

        public CatégoriesController(ICatégorieRepository catégorieRepository)
        {
            _catégorieRepository = catégorieRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Catégorie>> GetCatégories()
        {
            return await _catégorieRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Catégorie>> GetCatégories(int id)
        {
            return await _catégorieRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Catégorie>> PostCatégories([FromBody] Catégorie catégorie)
        {
            var newCatégorie = await _catégorieRepository.Create(catégorie);
            return CreatedAtAction(nameof(GetCatégories), new { id = newCatégorie.Id }, newCatégorie);
        }

        [HttpPut]
        public async Task<ActionResult<Catégorie>> PutCatégories(int id, [FromBody] Catégorie catégorie)
        {
            if (id != catégorie.Id)
            {
                return BadRequest();
            }
            await _catégorieRepository.Update(catégorie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Catégorie>> Delete(int id)
        {
            var produitToDelete = await _catégorieRepository.Get(id);
            if (produitToDelete == null)
                return NotFound();

            await _catégorieRepository.Delete(produitToDelete.Id);
            return NoContent();


        }

    }
}
