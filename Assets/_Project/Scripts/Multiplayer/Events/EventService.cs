using ServiceLocator;
using UnityEngine;

namespace Multiplayer.Events
{
    public sealed class EventService : MonoBehaviour, IEventService
    {
        private delegate void EventDelegate (ServiceEvent serviceEvent);

        private EventDelegate _current;
        
        private void Awake()
        {
            GameServices.RegisterService<IEventService>(this);
        }

        private void OnDestroy()
        {
            GameServices.DeregisterService<IEventService>();
        }

        public void AddEventListener<T>(IEventService.EventDelegate<T> listener) where T : ServiceEvent
        {
            _current = serviceEvent => listener((T) serviceEvent);
        }

        public void RemoveEventListener<T>(IEventService.EventDelegate<T> listener) where T : ServiceEvent
        {
            _current = null;
        }

        public void DispatchEvent(ServiceEvent dispatchEvent)
        {
            _current?.Invoke(dispatchEvent);
        }
    }
}
