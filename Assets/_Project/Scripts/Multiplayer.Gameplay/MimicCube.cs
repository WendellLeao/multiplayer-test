using Multiplayer.Gameplay.Events;
using ServiceLocator;
using UnityEngine;
using Mirror;

namespace Multiplayer.Gameplay
{
    public sealed class MimicCube : NetworkBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        public override void OnStartClient()
        {
            base.OnStartClient();
            
            IEventService eventService = GameServices.GetService<IEventService>();
        
            eventService.OnPlayerMaterialChanged += HandlePlayerMaterialChanged;
        }

        public override void OnStopClient()
        {
            base.OnStopClient();
            
            IEventService eventService = GameServices.GetService<IEventService>();
        
            eventService.OnPlayerMaterialChanged -= HandlePlayerMaterialChanged;
        }
        
        private void HandlePlayerMaterialChanged(Material material)
        {
            _meshRenderer.material = material;
        }
    }
}
