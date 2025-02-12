using System;
using System.Collections.Generic;

namespace BProject.Services
{
    public class AllServices
    {
        public static AllServices Instance => _instance ??= new AllServices();

        private static AllServices _instance;

        private Dictionary<Type, IService> _services = new();

        public void RegisterSingle<TService>(TService service) where TService : IService
            => _services.Add(typeof(TService), service);

        public TService Single<TService>() where TService : IService
            => (TService)_services.GetValueOrDefault(typeof(TService));
    }
}