using Amazon.SQS;
using AWSEKS_WebAPI.Models;
using AWSEKS_WebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSEKS_WebAPI.Controllers
{

    /// <summary>
    /// API Controller for communicating with SQS
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SQSProducerController : ControllerBase
    {

        /// <summary>
        /// The SQS Producer Service
        /// </summary>
        private readonly ISQSProducer _sqsProducer;

        /// <summary>
        /// Contructor to initialize the Controller 
        /// </summary>
        /// <param name="sqsProducer">The Producer Service to communicate with AWS queue</param>
        public SQSProducerController(ISQSProducer sqsProducer)
        {
            _sqsProducer = sqsProducer;
        }
        
        /// <summary>
        /// Send a message to SQS 
        /// </summary>
        /// <param name="message">The message that is sent to the queue</param>
        /// <returns>Returns an ok respsonse and the message that was sent to the queue</returns>
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] Message message)
        {
            var response = await _sqsProducer.SendMessageAsync(message);
            return Ok(response);
        }
        
        /// <summary>
        /// Get all the messages from the AWS SQS Queue
        /// </summary>
        /// <returns>Returns a list of messages from the queue</returns>
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var response = await _sqsProducer.GetMessagesAsync();
            return Ok(response);
        }

    }
}
