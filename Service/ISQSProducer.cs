using Amazon.SQS.Model;
using AWSEKS_WebAPI.Models;
using Message = AWSEKS_WebAPI.Models.Message;

namespace AWSEKS_WebAPI.Service
{
    /// <summary>
    /// Interface for communicating with AWS SQS Service
    /// </summary>
    public interface ISQSProducer
    {
        Task<Message> SendMessageAsync(Message message);
        Task<List<Message>> GetMessagesAsync();
    }
}
