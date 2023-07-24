namespace UserCrudWithAspDotNetCoreWithAngular.RabitMQ
{
    public interface IRabitMQProducer
    {
        public void SendUserMessage<T>(T message);
        public void SendUserByIdMessage<T>(T message);
    }
}
