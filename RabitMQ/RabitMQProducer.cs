using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace UserCrudWithAspDotNetCoreWithAngular.RabitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendUserByIdMessage<T>(T message)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new System.Uri("amqp://guest:guest@localhost:5672/");
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using
            var channel = connection.CreateModel();
            channel.ExchangeDeclare("exchange for return user by id", ExchangeType.Topic, true, false);
            
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the user queue
            channel.BasicPublish("exchange for return user by id", routingKey: "userById", body: body);
        }

        public void SendUserMessage<T>(T message)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new System.Uri("amqp://guest:guest@localhost:5672/");
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using var channel = connection.CreateModel();
            channel.ExchangeDeclare("faieem exchange",ExchangeType.Fanout, true, false);
            //declare the queue after mentioning name and a few property related to that
            //Serialize the message
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the user queue
            channel.BasicPublish("faieem exchange", routingKey: " ", body: body);
        }


    }
}
