using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Sale
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int SaleId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
    }
}