using LearnSignalR.Server;
using LearnSignalR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SmsApi.Models;

namespace LearnSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly SmsService _smsService;
        private readonly IHubContext<SMSHub> _hubContext;

        public SmsController(SmsService smsService, IHubContext<SMSHub> hubContext)
        {
            _smsService = smsService;
            _hubContext = hubContext;
        }

        [HttpGet]
        public ActionResult<List<SmsMessage>> Get() => _smsService.Get();

        [HttpGet("{id:length(24)}", Name = "GetSms")]
        public ActionResult<SmsMessage> Get(string id)
        {
            var sms = _smsService.Get(id);

            if (sms == null)
            {
                return NotFound();
            }

            return sms;
        }

        [HttpPost]
        public async Task<ActionResult<SmsMessage>> Create(SmsMessage sms)
        {
            _smsService.Create(sms);
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", sms.Message);
            return CreatedAtRoute("GetSms", new { id = sms.Id.ToString() }, sms);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, SmsMessage smsIn)
        {
            var sms = _smsService.Get(id);

            if (sms == null)
            {
                return NotFound();
            }

            _smsService.Update(id, smsIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var sms = _smsService.Get(id);

            if (sms == null)
            {
                return NotFound();
            }

            _smsService.Remove(sms.Id);

            return NoContent();
        }
    }
}
