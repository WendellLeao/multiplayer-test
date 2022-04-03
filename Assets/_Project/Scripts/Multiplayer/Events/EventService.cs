using System.Collections.Generic;
using Multiplayer.Events;
using UnityEngine.Events;
using ServiceLocator;
using UnityEngine;
using System;

namespace Multiplayer.EventManagers_master.Scripts
{
    public class EventService : MonoBehaviour, IEventService
    {
        private Dictionary<Type, UnityEvent<ServiceEvent>> _eventDictionary = new Dictionary<Type, UnityEvent<ServiceEvent>>();

        public void AddEventListener<T>(UnityAction<ServiceEvent> listener) where T : ServiceEvent
        {
            var type = typeof(T);
            
            UnityEvent<ServiceEvent> thisEvent = null;
            
            if (_eventDictionary.TryGetValue(type, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent<ServiceEvent>();
                
                thisEvent.AddListener(listener);
               
                _eventDictionary.Add(type, thisEvent);
            }
        }
        
        public void RemoveEventListener<T>(UnityAction<ServiceEvent> listener) where T : ServiceEvent
        {
            var type = typeof(T);
            
            UnityEvent<ServiceEvent> thisEvent = null;
            
            if (_eventDictionary.TryGetValue(type, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public void DispatchEvent(ServiceEvent serviceEvent)
        {
            var type = serviceEvent.GetType();
            
            UnityEvent<ServiceEvent> thisEvent = null;

            if (_eventDictionary.TryGetValue(type, out thisEvent))
            {
                thisEvent.Invoke(serviceEvent);
            }
        }
        
        private void Awake()
        {
            GameServices.RegisterService<IEventService>(this);
        }

        private void OnDestroy()
        {
            GameServices.DeregisterService<IEventService>();
        }
    }
}