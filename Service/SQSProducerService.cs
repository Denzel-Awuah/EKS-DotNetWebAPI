using Amazon.SQS;
using Amazon.SQS.Model;
using AWSEKS_WebAPI.Models;
using System.Text.Json;
using Message = AWSEKS_WebAPI.Models.Message;

namespace AWSEKS_WebAPI.Service
{
    /// <summary>
    /// Service for interacting with AWS SQS 
    /// </summary>
    public class SQSProducerService : ISQSProducer
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly string _queueUrl = "https://sqs.ca-central-1.amazonaws.com/544052154038/dotnet-eks";

        public SQSProducerService(IAmazonSQS sqsClient)
        {
            _sqsClient = sqsClient;
        }

        /// <summary>
        /// Retrieves all the messages from the Queue
        /// </summary>
        /// <returns>Returns a list of messages</returns>
        public async Task<List<Message>> GetMessagesAsync()
        {
            var request = new ReceiveMessageRequest
            {
                QueueUrl = _queueUrl,
            };
            var response = await _sqsClient.ReceiveMessageAsync(request);
            var messages = response.Messages
                .Select(m => JsonSerializer.Deserialize<Message>(m.Body))
                .ToList();
            return messages;
        }

        /// <summary>
        /// Sends a message to SQS
        /// </summary>
        /// <param name="message">The message that is sent to SQS</param>
        /// <returns>Returns the message</returns>
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
