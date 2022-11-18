using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MuseCritic.Models;
using MuseCritic.Models.Repository;
using MuseCritic.Repository.Abstractions;

namespace MuseCritic.Repository
{
    public class AlbumRepository : BaseRepository
    {
        private readonly IMongoCollection<Album> albumsCollection;

        public AlbumRepository(IOptions<MuseCriticDatabaseSettings> museCriticDatabaseSettingsOptions) : base(museCriticDatabaseSettingsOptions)
        {
            this.albumsCollection = this.database.GetCollection<Album>(museCriticDatabaseSettingsOptions.Value.AlbumsCollectionName);
        }

        public async Task<List<Album>> GetAsync()
        {
            return await this.albumsCollection.Find<Album>(_ => true).ToListAsync();
        }

        public async Task<Album> GetAsync(string id)
        {
            return await this.albumsCollection.Find<Album>(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Album album)
        {
            await this.albumsCollection.InsertOneAsync(album);
        }

        public async Task UpdateAsync(string id, Album updatedAlbum)
        {
            await this.albumsCollection.ReplaceOneAsync(x => x.Id == id, updatedAlbum);
        }

        public async Task RemoveAsync(string id)
        {
            await this.albumsCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
