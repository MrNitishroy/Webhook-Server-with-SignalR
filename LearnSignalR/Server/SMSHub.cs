using Microsoft.AspNetCore.SignalR;
using SmsApi.Models;

namespace LearnSignalR.Server
{
    public class SMSHub : Hub
    {
        public async Task SendMessage(SmsMessage message)
        {
            await Clients.All.SendAsync("ReceiveMessage",message);
        }
    }
}
