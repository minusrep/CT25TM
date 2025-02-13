using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.Services
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetsProvider;

        private RootView _rootView;
        
        public GameFactory(IAssetProvider assetProvider)
        {
            _assetsProvider = assetProvider;
        }

        public void CreateRootView()
        {
            _rootView = _assetsProvider.Instantiate(AssetPath.RootView).GetComponent<RootView>();

            _rootView.Construct(this);
        }

        public TView CreateUIView<TView>() where TView : UIView
        {
            var path = $"{AssetPath.UIFolder}/{typeof(TView).Name}";
            
            var view = _assetsProvider.Instantiate(path, _rootView.transform).GetComponent<TView>();
            
            view.Construct();

            return view;
        }
    }
}