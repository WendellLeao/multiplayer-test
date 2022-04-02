using UnityEngine;
using System;

namespace Multiplayer.Gameplay.Events
{
    public interface IEventService
    {
        event Action<Material> OnPlayerMaterialChanged;
        
        void DispatchPlayerMaterialEvent(Material material);
    }
}