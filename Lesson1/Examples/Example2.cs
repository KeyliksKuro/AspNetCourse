namespace Lesson1.Examples.Example2
{
    //Класс Message не зависит от конкретной реализации класса Logger -
    //это может быть любая реализация интерфейса ILogger.
    interface ILogger
    {
        void Log(string message);
    }
    class Logger : ILogger
    {
        public void Log(string message) => Console.WriteLine(message);
    }
    class Message
    {
        ILogger logger;
        public string Text { get; set; } = "";
        public Message(ILogger logger)
        {
            this.logger = logger;
        }
        public void Print() => logger.Log(Text);
    }
}
