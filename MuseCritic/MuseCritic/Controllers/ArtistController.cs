using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseCritic.Models;
using MuseCritic.Repository;

namespace MuseCritic.Controllers
{
    [Route("api/artist")]
    public class ArtistController : ControllerBase
	{
        private readonly ArtistRepository artistRepository;

        public ArtistController(ArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository ?? throw new ArgumentNullException(nameof(artistRepository), "A non-null artist Repository must be injected.");
        }

        [HttpGet]
        public async Task<List<Artist>> Get()
        {
            return await this.artistRepository.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Artist>> Get(string id)
        {
            var artist = await this.artistRepository.GetAsync(id);

            if (artist == null)
            {
                return new NotFoundResult();
            }

            return artist;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Artist artist)
        {
            await this.artistRepository.CreateAsync(artist);

            return new CreatedAtActionResult(actionName: nameof(Get), controllerName: "artist", routeValues: new { id = artist.Id }, value: artist);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Artist updatedArtist)
        {
            var currentArtist = await this.artistRepository.GetAsync(id);

            if (currentArtist is null)
            {
                return NotFound();
            }

            updatedArtist.Id = currentArtist.Id;

            await this.artistRepository.UpdateAsync(id, updatedArtist);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var artist = await this.artistRepository.GetAsync(id);

            if (artist is null)
            {
                return NotFound();
            }

            await this.artistRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}

