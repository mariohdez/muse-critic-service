using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MuseCritic.Models;
using MuseCritic.Models.DataStore;

namespace MuseCritic.Repository
{
    public class AlbumRepository
    {
        private readonly IMongoCollection<Album> albumsCollection;

        public AlbumRepository(IOptions<MuseCriticDatabaseSettings> museCriticDatabaseSettingsOptions)
        {
            _ = museCriticDatabaseSettingsOptions ?? throw new ArgumentNullException(nameof(museCriticDatabaseSettingsOptions), "Argument must be set.");

            var mongoClient = new MongoClient(museCriticDatabaseSettingsOptions.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(museCriticDatabaseSettingsOptions.Value.DatabaseName);
            this.albumsCollection = mongoDatabase.GetCollection<Album>(museCriticDatabaseSettingsOptions.Value.AlbumsCollectionName);
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
    }
}

