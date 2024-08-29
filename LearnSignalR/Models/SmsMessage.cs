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
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
