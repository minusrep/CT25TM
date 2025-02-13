using UnityEngine;

namespace BProject.Services
{
    public interface IGameFactory : IService
    {
        void CreateRootView();
        TView CreateUIView<TView>() where TView : UIView;
    }
}