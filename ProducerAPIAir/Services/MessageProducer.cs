using RabbitMQ.Client;
using System.Text;
using System.Text.Json;


namespace ProducerAPIAir.Services
{
    public class MessageProducer: IMessageProducer
    {
        public void SendingMessage<T>(T message)
        {
            //ConnectionFactory factory = new();

            //factory.Uri = new Uri("amqp:// user:user:@localhost:5672");

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
                Port = 5672
            };
            var conn = factory.CreateConnection();
            using var channel = conn.CreateModel();
            channel.QueueDeclare("bookings", false,false,false,null);
            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", "bookings",null,body);

        }
    }
}
