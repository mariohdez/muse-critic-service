using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MuseCritic.Models
{
	public class Review
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [BsonElement("UserID")]
        [JsonPropertyName("userId")]
        public string UserID { get; set; }

        [BsonElement("AlbumID")]
        [JsonPropertyName("albumId")]
        public string AlbumID { get; set; }

        [BsonElement("ArtistID")]
        [JsonPropertyName("artistId")]
        public string ArtistID { get; set; }

        [BsonElement("Rating")]
        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [BsonElement("ReviewText")]
        [JsonPropertyName("reviewText")]
        public string ReviewText { get; set; }
    }
}

