using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MallconomyCase.Models
{
    public class UserPoint
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public string? Id { get; set; }

        [BsonElement("approved")]
        public bool Approved { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("user_id")]
        [Required]
        public string? UserId { get; set; }

        [BsonElement("point")]
        [Required]
        public int Point { get; set; }
        public DateTime Date { get; set; }
    }
}
