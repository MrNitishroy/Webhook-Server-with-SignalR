// Services/SmsService.cs
using MongoDB.Driver;
using SmsApi.Models;
using Microsoft.Extensions.Configuration;

namespace LearnSignalR.Services
{
    public class SmsService
    {
        private readonly IMongoCollection<SmsMessage> _smsMessages;

        public SmsService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("SmsDb"));
            var database = client.GetDatabase("SmsDb");
            _smsMessages = database.GetCollection<SmsMessage>("SmsMessages");
        }

        public List<SmsMessage> Get() => _smsMessages.Find(sms => true).ToList();

        public SmsMessage Get(string id) => _smsMessages.Find<SmsMessage>(sms => sms.Id == id).FirstOrDefault();

        public SmsMessage Create(SmsMessage sms)
        {
            _smsMessages.InsertOne(sms);
            return sms;
        }

        public void Update(string id, SmsMessage smsIn) => _smsMessages.ReplaceOne(sms => sms.Id == id, smsIn);

        public void Remove(SmsMessage smsIn) => _smsMessages.DeleteOne(sms => sms.Id == smsIn.Id);

        public void Remove(string id) => _smsMessages.DeleteOne(sms => sms.Id == id);
    }
}
