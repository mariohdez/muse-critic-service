using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MuseCritic.Models
{
    public class Album
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonElement("ArtistID")]
        [JsonPropertyName("artistId")]
        public string ArtistID { get; set; }

        [BsonElement("OverallRating")]
        [JsonPropertyName("overallRating")]
        public double OverallRating { get; set; }

        [BsonElement("RatingsCount")]
        [JsonPropertyName("ratingsCount")]
        public int RatingsCount { get; set; }

        [BsonElement("CoverArtURL")]
        [JsonPropertyName("coverArtUrl")]
        public string CoverArtURL { get; set; }
    }
}
