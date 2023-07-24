﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace UserCrudWithAspDotNetCoreWithAngular.RabitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendUserByIdMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using
            var channel = connection.CreateModel();
            channel.ExchangeDeclare("Faieem", ExchangeType.Fanout, true, false);

        }

        public void SendUserMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using
            var channel = connection.CreateModel();
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare("users",true,false,false);
            //Serialize the message
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the user queue
            channel.BasicPublish(exchange: "", routingKey: "users", body: body);
        }


    }
}
