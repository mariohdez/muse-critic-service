using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MuseCritic.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ProfilePictureURL﻿ { get; set; }

        public string Biography { get; set; }
    }
}
