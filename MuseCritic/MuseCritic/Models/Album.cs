using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MuseCritic.Models
{
    public class Album
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; }

        public string ArtistID { get; set; }

        public double OverallRating { get; set; }

        public int RatingsCount { get; set; }

        public string CoverArtURL { get; set; }
    }
}
