using System;
namespace MuseCritic.Models.DataStore
{
    public class MuseCriticDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string AlbumsCollectionName { get; set; } = null!;
    }
}
