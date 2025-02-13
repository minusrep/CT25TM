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
            var rootView = _assetsProvider.Instantiate(AssetPath.RootView).GetComponent<RootView>();

            rootView.GetComponent<RootView>().Construct(this);
        }

        public SeasonsView CreateSeasonsView()
        {
            var seasonsView = _assetsProvider.Instantiate(AssetPath.SeasonsView).GetComponent<SeasonsView>();
            
            seasonsView.Construct();
            
            return seasonsView;
        }
    }
}