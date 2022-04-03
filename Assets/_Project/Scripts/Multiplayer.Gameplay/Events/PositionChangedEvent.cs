using Multiplayer.Events;
using UnityEngine;

namespace Multiplayer.Gameplay.Events
{
    public sealed class PositionChangedEvent : ServiceEvent
    {
        public PositionChangedEvent(Vector3 position)
        {
            Position = position;
        }
        
        public Vector3 Position { get; }
    }
}