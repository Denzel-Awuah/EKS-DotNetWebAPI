using Amazon.SQS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSEKS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SQSProducerController : ControllerBase
    {

        private IAmazonSQS sqsClient;

        public SQSProducerController(IAmazonSQS sQSClient)
        {
            sqsClient = sQSClient;
        }



    }
}
