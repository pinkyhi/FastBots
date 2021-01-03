using System;

namespace FastBots.Commands
{
    class Payment : ACommand
    {
        public Payment(string command) : base(command)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("Payment");
        }
    }
}