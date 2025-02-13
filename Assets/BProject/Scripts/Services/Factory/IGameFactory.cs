using UnityEngine;

namespace BProject.Services
{
    public interface IGameFactory : IService
    {
        void CreateRootView();
        SeasonsView CreateSeasonsView();
    }
}