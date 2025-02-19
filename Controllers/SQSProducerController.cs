using Amazon.SQS;
using AWSEKS_WebAPI.Models;
using AWSEKS_WebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSEKS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SQSProducerController : ControllerBase
    {

        private readonly ISQSProducer _sqsProducer;

        public SQSProducerController(ISQSProducer sqsProducer)
        {
            _sqsProducer = sqsProducer;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] Message message)
        {
            var response = await _sqsProducer.SendMessageAsync(message);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var response = await _sqsProducer.GetMessagesAsync();
            return Ok(response);
        }

    }
}
