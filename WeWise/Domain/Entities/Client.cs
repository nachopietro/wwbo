using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Client
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CompanyName { get; set; }
        public bool IsActive { get; set; }
    }
}