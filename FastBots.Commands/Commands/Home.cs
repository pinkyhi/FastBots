using System;

namespace FastBots.Commands
{
    class Home : ACommand
    {
        public Home(string command) : base(command)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("Home");
        }
    }
}