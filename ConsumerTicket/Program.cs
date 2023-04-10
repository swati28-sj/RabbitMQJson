using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

Console.WriteLine("Welcome to the Ticket Service");

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
channel.QueueDeclare("bookings", false, false, false, null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, EventArgs) =>
{
    var body = EventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" A message for new ticket has been initiated - {message}");
};
channel.BasicConsume("bookings",true, consumer);
Console.ReadKey();