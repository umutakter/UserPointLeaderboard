using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MallconomyCase.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int TotalPoint { get; set; }
        public int Rank { get; set; }
        public string Award { get; set; }
    }
}
