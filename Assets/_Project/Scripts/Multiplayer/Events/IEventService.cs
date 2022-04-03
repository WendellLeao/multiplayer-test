namespace Multiplayer.Events
{
    public interface IEventService
    {
        delegate void EventDelegate<T> (T e) where T : ServiceEvent;

        void AddEventListener<T>(EventDelegate<T> listener) where T : ServiceEvent;
        void RemoveEventListener<T>(EventDelegate<T> listener) where T : ServiceEvent;
        void DispatchEvent(ServiceEvent dispatchEvent);
    }
}