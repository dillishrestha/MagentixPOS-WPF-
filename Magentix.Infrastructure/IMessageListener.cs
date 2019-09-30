using System;

namespace Magentix.Infrastructure
{
    public interface IMessageListener
    {
        string Key { get; }
        void ProcessMessage(string message);
    }
}
