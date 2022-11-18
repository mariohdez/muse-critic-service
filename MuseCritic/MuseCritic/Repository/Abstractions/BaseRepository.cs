using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MuseCritic.Models;
using MuseCritic.Models.Repository;

namespace MuseCritic.Repository.Abstractions
{
    public abstract class BaseRepository
    {
        protected readonly IMongoDatabase database;

        public BaseRepository(IOptions<MuseCriticDatabaseSettings> museCriticDatabaseSettingsOptions)
        {
            _ = museCriticDatabaseSettingsOptions ?? throw new ArgumentNullException(nameof(museCriticDatabaseSettingsOptions), "Argument must be set.");

            var mongoClient = new MongoClient(museCriticDatabaseSettingsOptions.Value.ConnectionString);
            this.database = mongoClient.GetDatabase(museCriticDatabaseSettingsOptions.Value.DatabaseName);
        }
    }
}
