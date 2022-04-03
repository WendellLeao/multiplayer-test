using Multiplayer.Events;
using UnityEngine;

namespace Multiplayer.Gameplay.Events
{
    public sealed class MaterialChangedEvent : ServiceEvent
    {
        public MaterialChangedEvent(Material material)
        {
            Material = material;
        }
        
        public Material Material { get; }
    }
}