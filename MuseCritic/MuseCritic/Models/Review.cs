using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MuseCritic.Models
{
	public class Review
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string UserID { get; set; }

        public string AlbumID { get; set; }

        public string ArtistID { get; set; }

        public int Rating { get; set; }

        public string ReviewText { get; set; }
    }
}

