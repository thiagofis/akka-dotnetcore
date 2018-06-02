using System;
using Akka.Actor;
using Akka.NetCore.Actors;
using Akka.NetCore.Messages;

namespace Akka.NetCore
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var movieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
            
            Props playbackActorProps = Props.Create<PlaybackActor>();
            IActorRef playbackActorRef = movieStreamingActorSystem.ActorOf(playbackActorProps, nameof(PlaybackActor));
            playbackActorRef.Tell(new PlaybackMessage{Name = "New message1"});
            playbackActorRef.Tell(new PlaybackMessage{Name = "New message2"});
            playbackActorRef.Tell(new PlaybackMessage{Name = "New message3"});
            playbackActorRef.Tell(PoisonPill.Instance);
            playbackActorRef.Tell(new PlaybackMessage{Name = "New message4"});
            playbackActorRef.Tell(new PlaybackMessage{Name = "New message5"});
            playbackActorRef.Tell(new PlaybackMessage{Name = "New message6"});

            Console.ReadKey();
            
            movieStreamingActorSystem.Terminate().Wait();
            Console.WriteLine("Terminate MovieStreamingActorSystem");
        }
    }
}