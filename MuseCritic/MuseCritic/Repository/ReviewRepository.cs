using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MuseCritic.Models;
using MuseCritic.Models.Repository;
using MuseCritic.Repository.Abstractions;

namespace MuseCritic.Repository
{
    public class ReviewRepository : BaseRepository
    {
        private readonly IMongoCollection<Review> reviewsCollection;

        public ReviewRepository(IOptions<MuseCriticDatabaseSettings> museCriticDatabaseSettingsOptions) : base(museCriticDatabaseSettingsOptions)
        {
            this.reviewsCollection = this.database.GetCollection<Review>(museCriticDatabaseSettingsOptions.Value.ReviewsCollectionName);
        }

        public async Task<List<Review>> GetAsync()
        {
            return await this.reviewsCollection.Find<Review>(_ => true).ToListAsync();
        }

        public async Task<Review> GetAsync(string id)
        {
            return await this.reviewsCollection.Find<Review>(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Review review)
        {
            await this.reviewsCollection.InsertOneAsync(review);
        }

        public async Task UpdateAsync(string id, Review updatedReview)
        {
            await this.reviewsCollection.ReplaceOneAsync(x => x.Id == id, updatedReview);
        }

        public async Task RemoveAsync(string id)
        {
            await this.reviewsCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
