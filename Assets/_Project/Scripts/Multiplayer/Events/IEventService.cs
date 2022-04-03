using UnityEngine.Events;

namespace Multiplayer.Events
{
    public interface IEventService
    {
        public void AddEventListener<T>(UnityAction<ServiceEvent> listener) where T : ServiceEvent;
        public void RemoveEventListener<T>(UnityAction<ServiceEvent> listener) where T : ServiceEvent;
        public void DispatchEvent(ServiceEvent serviceEvent);
    }
}