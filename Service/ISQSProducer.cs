using AWSEKS_WebAPI.Models;

namespace AWSEKS_WebAPI.Service
{
    public interface ISQSProducer
    {
        Task<Message> SendMessageAsync(Message message);
    }
}
