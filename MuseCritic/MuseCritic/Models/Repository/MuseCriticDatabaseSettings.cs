using System;
namespace MuseCritic.Models.Repository
{
    public class MuseCriticDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string AlbumsCollectionName { get; set; } = null!;

        public string UsersCollectionName { get; set; } = null!;

        public string ArtistsCollectionName { get; set; } = null!;

        public string ReviewsCollectionName { get; set; } = null!;
    }
}
