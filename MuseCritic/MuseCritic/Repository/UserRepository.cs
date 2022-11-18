using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MuseCritic.Models;
using MuseCritic.Models.Repository;
using MuseCritic.Repository.Abstractions;

namespace MuseCritic.Repository
{
    public class UserRepository : BaseRepository
    {
        private readonly IMongoCollection<User> usersCollection;

        public UserRepository(IOptions<MuseCriticDatabaseSettings> museCriticDatabaseSettingsOptions) : base(museCriticDatabaseSettingsOptions)
        {
            this.usersCollection = this.database.GetCollection<User>(museCriticDatabaseSettingsOptions.Value.UsersCollectionName);
        }

        public async Task<List<User>> GetAsync()
        {
            return await this.usersCollection.Find<User>(_ => true).ToListAsync();
        }

        public async Task<User> GetAsync(string id)
        {
            return await this.usersCollection.Find<User>(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(User user)
        {
            await this.usersCollection.InsertOneAsync(user);
        }

        public async Task UpdateAsync(string id, User updatedUser)
        {
            await this.usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);
        }

        public async Task RemoveAsync(string id)
        {
            await this.usersCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
