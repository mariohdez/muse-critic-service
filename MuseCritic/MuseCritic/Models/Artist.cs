using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MuseCritic.Models
{
    public class Artist
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonElement("Biography")]
        [JsonPropertyName("biography")]
        public string Biography { get; set; }

        [BsonElement("ProfilePictureURL﻿")]
        [JsonPropertyName("profilePictureUrl")]
        public string ProfilePictureURL﻿ { get; set; }
    }
}
