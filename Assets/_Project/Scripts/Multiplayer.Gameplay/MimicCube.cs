using Multiplayer.Gameplay.Events;
using Multiplayer.Events;
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
            
            eventService.AddEventListener<MaterialChangedEvent>(HandleMaterialChanged);
        }

        public override void OnStopClient()
        {
            base.OnStopClient();
            
            IEventService eventService = GameServices.GetService<IEventService>();
            
            eventService.RemoveEventListener<MaterialChangedEvent>(HandleMaterialChanged);
        }
        
        private void HandleMaterialChanged(ServiceEvent serviceEvent)
        {
            if (serviceEvent is MaterialChangedEvent materialChangedEvent)
            {
                Material newMaterial = materialChangedEvent.Material;
                
                _meshRenderer.material = newMaterial;
            }
        }
    }
}
