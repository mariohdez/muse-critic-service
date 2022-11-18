using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseCritic.Models;
using MuseCritic.Repository;

namespace MuseCritic.Controllers
{
    [Route("api/album")]
    public class AlbumController : ControllerBase
    {
        private readonly AlbumRepository albumRepository;

        public AlbumController(AlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository ?? throw new ArgumentNullException(nameof(albumRepository), "A non-null album Repository must be injected.");
        }

        [HttpGet]
        public async Task<List<Album>> Get()
        {
            return await this.albumRepository.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Album>> Get(string id)
        {
            var album = await this.albumRepository.GetAsync(id);

            if (album == null)
            {
                return new NotFoundResult();
            }

            return album;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Album album)
        {
            await this.albumRepository.CreateAsync(album);

            return new CreatedAtActionResult(actionName: nameof(Get), controllerName: "album", routeValues: new { id = album.Id }, value: album);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Album updatedAlbum)
        {
            var currentAlbum = await this.albumRepository.GetAsync(id);

            if (currentAlbum is null)
            {
                return NotFound();
            }

            updatedAlbum.Id = currentAlbum.Id;

            await this.albumRepository.UpdateAsync(id, updatedAlbum);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var album = await this.albumRepository.GetAsync(id);

            if (album is null)
            {
                return NotFound();
            }

            await this.albumRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}
