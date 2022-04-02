using ServiceLocator;
using UnityEngine;
using System;

namespace Multiplayer.Gameplay.Events
{
    public sealed class EventService : MonoBehaviour, IEventService
    {
        public event Action<Material> OnPlayerMaterialChanged;

        private void Awake()
        {
            GameServices.RegisterService<IEventService>(this);
        }

        private void OnDestroy()
        {
            GameServices.DeregisterService<IEventService>();
        }

        public void DispatchPlayerMaterialEvent(Material material)
        {
            OnPlayerMaterialChanged?.Invoke(material);
        }
    }
}
