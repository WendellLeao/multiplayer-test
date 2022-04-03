using System.Collections.Generic;

namespace ServiceLocator
{
    public static class GameServices
    {
        private static readonly Dictionary<int, object> _serviceMap;

        static GameServices()
        {
            _serviceMap = new Dictionary<int, object>();
        }

        public static void RegisterService<T>(T service) where T : class
        {
            _serviceMap[typeof(T).GetHashCode()] = service;
        }

        public static void DeregisterService<T>() where T : class
        {
            _serviceMap.Remove(typeof(T).GetHashCode());
        }

        public static T GetService<T>() where T : class
        {
            object service;
            
            _serviceMap.TryGetValue(typeof(T).GetHashCode(), out service);
            
            return (T) service;
        }
    }
}