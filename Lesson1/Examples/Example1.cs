namespace Lesson1.Examples.Example1
{
    //Здесь сущность Message, которая представляет некоторое сообщение,
    //зависит от другой сущности - Logger, которая представляет логгер.
    class Logger
    {
        public void Log(string message) => Console.WriteLine(message);
    }
    class Message
    {
        Logger logger = new Logger();
        public string Text { get; set; } = "";
        public void Print() => logger.Log(Text);
    }
}
