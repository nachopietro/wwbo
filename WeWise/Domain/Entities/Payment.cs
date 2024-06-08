using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Payment
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int PaymentId { get; set; }
        public int SaleId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public string? PaymentMethod { get; set; }
    }
}