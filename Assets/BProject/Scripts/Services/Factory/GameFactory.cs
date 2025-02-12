namespace BProject.Services
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetsProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetsProvider = assetProvider;
        }
    }
}