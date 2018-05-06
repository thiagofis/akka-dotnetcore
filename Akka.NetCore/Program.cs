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
            playbackActorRef.Tell(new PlaybackMessage{Name = "New message"});

            Console.ReadKey();
            
            movieStreamingActorSystem.Terminate().Wait();
            Console.WriteLine("Terminate MovieStreamingActorSystem");
        }
    }
}