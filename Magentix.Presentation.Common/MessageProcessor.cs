using Magentix.Presentation.Services.Common;

namespace Magentix.Presentation.Common
{
    public static class MessageProcessor
    {
        public static void ProcessMessage(string message)
        {
            new Message(message).PublishEvent(EventTopicNames.MessageReceivedEvent);
        }
    }
}
