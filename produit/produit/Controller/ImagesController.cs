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
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
       
        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Image>> GetImages()
        {
            return await _imageRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImages(int id)
        {
            return await _imageRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Image>> PostImages([FromBody] Image image)
        {
            var newImage = await _imageRepository.Create(image);
            return CreatedAtAction(nameof(newImage), new { id = newImage.Id }, newImage);
        }

        [HttpPut]
        public async Task<ActionResult<Image>> PutImages(int id, [FromBody] Image image)
        {
            if (id != image.Id)
            {
                return BadRequest();
            }
            await _imageRepository.Update(image);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Image>> Delete(int id)
        {
            var ImageToDelete = await _imageRepository.Get(id);
            if (ImageToDelete == null)
                return NotFound();

            await _imageRepository.Delete(ImageToDelete.Id);
            return NoContent();

        }

    }
}
