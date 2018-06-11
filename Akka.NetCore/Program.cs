using System;
using Akka.Actor;
using Akka.Configuration;
using Akka.NetCore.Actors;
using Akka.NetCore.Messages;

namespace Akka.NetCore
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // First example of Akka.Net Core using ReceiveActor and PoisonPill
            ReceiveActorAndPoisonPillMessageExample();
            
            // Second example of Akka.Net Core use Switchabel Actor Behaviour
            SwitchabelActorBehaviourExample();
        }

        private static void SwitchabelActorBehaviourExample()
        {
            var paymentTransactionActorSystem = ActorSystem.Create("PaymentTransactionActorSystem");
            
            Props paymentTransactionActorProps = Props.Create<PaymentTransactionActor>();
            IActorRef paymentTransactionActorRef =
                paymentTransactionActorSystem.ActorOf(paymentTransactionActorProps, nameof(PaymentTransactionActor));
            
            paymentTransactionActorRef.Tell(new AutorizationMessage());
            paymentTransactionActorRef.Tell(new CaptureMessage());
            paymentTransactionActorRef.Tell(new RefaundMessage());
            paymentTransactionActorRef.Tell(new AutorizationMessage());
            
            Console.ReadKey();

            paymentTransactionActorSystem.Terminate().Wait();
            Console.WriteLine("Terminate PaymentTransactionActorSystem");
        }

        private static void ReceiveActorAndPoisonPillMessageExample()
        {
            var movieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");

            Props playbackActorProps = Props.Create<PlaybackActor>();
            IActorRef playbackActorRef = movieStreamingActorSystem.ActorOf(playbackActorProps, nameof(PlaybackActor));
            playbackActorRef.Tell(new PlaybackMessage("New message1"));
            playbackActorRef.Tell(new PlaybackMessage("New message2"));
            playbackActorRef.Tell(new PlaybackMessage("New message3"));
            playbackActorRef.Tell(PoisonPill.Instance);
            playbackActorRef.Tell(new PlaybackMessage("New message4"));
            playbackActorRef.Tell(new PlaybackMessage("New message5"));
            playbackActorRef.Tell(new PlaybackMessage("New message6"));

            Console.ReadKey();

            movieStreamingActorSystem.Terminate().Wait();
            Console.WriteLine("Terminate MovieStreamingActorSystem");
        }

        private static void ActorSupervisionHierarchyExample()
        {
            
        }
    }
}