using System;
using Akka.Actor;
using Akka.NetCore.Messages;
using Akka.NetCore.Utils;

namespace Akka.NetCore.Actors
{
    public class PlaybackActor : ReceiveActor
    {
        
        public PlaybackActor()
        {
            Receive<PlaybackMessage>(msg => HandlerMessage(msg));
        }

        private void HandlerMessage(string message)
        {
            Console.WriteLine(message);
        }
        
        private void HandlerMessage(PlaybackMessage message)
        {
            Console.WriteLine($"HandlerMessage: {message.Name}");
        }

        protected override void PreStart()
        {
            ConsoleUtil.WriteColor("===PreStart===", ConsoleColor.Green);
        }
        
        protected override void PostStop()
        {
            ConsoleUtil.WriteColor("===PostStop===", ConsoleColor.Red);
        }
        
        protected override void PostRestart(Exception reason)
        {
            ConsoleUtil.WriteColor("===PostRestart===", ConsoleColor.Blue);
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ConsoleUtil.WriteColor("===PostRestart===", ConsoleColor.Yellow);
        }
    }
}