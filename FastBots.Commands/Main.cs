namespace FastBots.Commands
{
    public class Main
    {
        public static void main()
        {
            Bot bot = new Bot("2blji4bhio04wuHFrjeoj23");
            
            bot.commands.AddCommand(new Home("/home"));
            
            bot.StartReceiving();
        }
    }
}