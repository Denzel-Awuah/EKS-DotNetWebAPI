using Amazon.SQS;
using Amazon.SQS.Model;
using AWSEKS_WebAPI.Models;
using System.Text.Json;
using Message = AWSEKS_WebAPI.Models.Message;

namespace AWSEKS_WebAPI.Service
{
    public class SQSProducerService : ISQSProducer
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly string _queueUrl = "https://sqs.ca-central-1.amazonaws.com/544052154038/dotnet-eks";

        public SQSProducerService(IAmazonSQS sqsClient)
        {
            _sqsClient = sqsClient;
        }
        public async Task<Message> SendMessageAsync(Message message)
        {
            var request = new SendMessageRequest
            {
                QueueUrl = _queueUrl,
                MessageBody = JsonSerializer.Serialize(message)
            };
            var response = await _sqsClient.SendMessageAsync(request);

            return message;
        }
    }
}
