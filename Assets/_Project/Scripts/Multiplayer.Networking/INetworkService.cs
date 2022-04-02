using System;

namespace Multiplayer.Networking
{
    public interface INetworkService
    {
        event Action OnServerStarted;
    }
}