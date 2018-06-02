namespace Akka.NetCore.Messages
{
    public class PlaybackMessage
    {
        public PlaybackMessage(string name)
        {
            Name = name;
        }
        
        
        public string Name { get; }   
    }
}