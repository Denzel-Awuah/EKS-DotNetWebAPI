using Amazon.SQS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSEKS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SQSProducerController : ControllerBase
    {

        private IAmazonSQS SQSClient;

        public SQSProducerController(IAmazonSQS sQSClient)
        {
            SQSClient = sQSClient;
        }

    }
}
