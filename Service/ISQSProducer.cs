using Amazon.SQS.Model;
using AWSEKS_WebAPI.Models;
using Message = AWSEKS_WebAPI.Models.Message;

namespace AWSEKS_WebAPI.Service
{
    public interface ISQSProducer
    {
        Task<Message> SendMessageAsync(Message message);
        Task<List<Message>> GetMessagesAsync();
    }
}
