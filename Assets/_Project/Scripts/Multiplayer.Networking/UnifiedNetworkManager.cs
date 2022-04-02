using ServiceLocator;
using System;
using Mirror;

namespace Multiplayer.Networking
{
    public sealed class UnifiedNetworkManager : NetworkManager, INetworkService
    {
        public event Action OnServerStarted;
        
        public override void Awake()
        {
            base.Awake();
            
            GameServices.RegisterService<INetworkService>(this);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            
            GameServices.DeregisterService<INetworkService>();
        }
        
        public override void OnStartServer()
        {
            base.OnStartServer();
            
            OnServerStarted?.Invoke();
        }
    }
}