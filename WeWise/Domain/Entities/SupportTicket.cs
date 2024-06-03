using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class SupportTicket
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int SupportTicketId { get; set; }
        public string? ClientId { get; set; }
        public string? ProductId { get; set; }
        public string? Issue { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
    }
}