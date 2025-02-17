namespace AWSEKS_WebAPI.Models
{
    public class Message
    {
        public int id { get; set; } 
        public string content { get; set; }

        public Message(int id, string content)
        {
            this.id = id;
            this.content = content;
        }
    }
}
