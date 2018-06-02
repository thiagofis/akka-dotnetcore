using System;
using Akka.Actor;
using Akka.NetCore.Messages;
using Akka.NetCore.Utils;

namespace Akka.NetCore.Actors
{
    public class PaymentTransactionActor : ReceiveActor
    {
        public PaymentTransactionActor()
        {
            Authorization();
        }

        private void Authorization()
        {
            Receive<AutorizationMessage>(msg =>
                HandlerMessage("===AutorizationMessage Received===", Capture));
        }

        private void Capture()
        {
            Receive<CaptureMessage>(msg =>
                HandlerMessage("===CaptureMessage Received===", Refaund));
        }

        private void Refaund()
        {
            Receive<RefaundMessage>(msg =>
                HandlerMessage("===RefaundMessage Received===", Authorization));
        }

        private void HandlerMessage(string message, Action action)
        {
            ConsoleUtil.WriteColor(message, ConsoleColor.Blue);
            Become(action);
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