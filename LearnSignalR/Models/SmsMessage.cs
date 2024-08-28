// Models/SmsMessage.cs
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmsApi.Models
{
    public class SmsMessage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }

        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
