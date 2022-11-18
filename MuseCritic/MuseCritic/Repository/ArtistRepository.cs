using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MuseCritic.Models;
using MuseCritic.Models.Repository;
using MuseCritic.Repository.Abstractions;

namespace MuseCritic.Repository
{
    public class ArtistRepository : BaseRepository
    {
        private readonly IMongoCollection<Artist> artistsCollection;

        public ArtistRepository(IOptions<MuseCriticDatabaseSettings> museCriticDatabaseSettingsOptions) : base(museCriticDatabaseSettingsOptions)
        {
            this.artistsCollection = this.database.GetCollection<Artist>(museCriticDatabaseSettingsOptions.Value.ArtistsCollectionName);
        }

        public async Task<List<Artist>> GetAsync()
        {
            return await this.artistsCollection.Find<Artist>(_ => true).ToListAsync();
        }

        public async Task<Artist> GetAsync(string id)
        {
            return await this.artistsCollection.Find<Artist>(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Artist artist)
        {
            await this.artistsCollection.InsertOneAsync(artist);
        }
    }
}

