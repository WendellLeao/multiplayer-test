using Multiplayer.Gameplay.Events;
using Multiplayer.Events;
using ServiceLocator;
using Mirror;
using UnityEngine;

namespace Multiplayer.Gameplay
{
    public sealed class MimicSphere : NetworkBehaviour
    {
        public override void OnStartClient()
        {
            base.OnStartClient();
            
            IEventService eventService = GameServices.GetService<IEventService>();
            
            eventService.AddEventListener<PositionChangedEvent>(HandlePositionChanged);
        }

        public override void OnStopClient()
        {
            base.OnStopClient();
            
            IEventService eventService = GameServices.GetService<IEventService>();
            
            eventService.RemoveEventListener<PositionChangedEvent>(HandlePositionChanged);
        }
        
        private void HandlePositionChanged(ServiceEvent serviceEvent)
        {
            if (serviceEvent is PositionChangedEvent positionChangedEvent)
            {
                Transform mimicTransform = transform; 
                
                Vector3 position = mimicTransform.position;

                float targetPosition = positionChangedEvent.Position.x;
                
                Vector3 horizontalPosition = new Vector3(targetPosition, position.y, position.z);

                mimicTransform.position = horizontalPosition;
            }
        }
    }
}