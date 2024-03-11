using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSApp.Model;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMSApp.Controllers
{
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ITwilioRestClient _client;

        public SmsController(ITwilioRestClient client)
        {
            _client = client;
        }

        [HttpPost("api/sendsms")]
        public IActionResult SendMessage(SmsMessage model)
        {
            var message = MessageResource.Create(
                to: new PhoneNumber(model.To),
                from: new PhoneNumber(model.From),
                body: model.Message,
                client: _client);

            return Ok("Success:" + message.AccountSid);
        }


    }
}
