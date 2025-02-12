using BProject.Services;

namespace BProject.Core.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly SceneLoader _sceneLoader;
        
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            
            _sceneLoader = sceneLoader;
            
            _services = services;
            
            RegisterServices();
        }
        
        public void Enter()
        {
            _sceneLoader.LoadScene(SceneId.Initial, EnterLoadingState);
            
            _stateMachine.Enter<LoadingState, int>( 12);
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            
            _services.RegisterSingle<IGameFactory>(new GameFactory(AllServices.Instance.Single<IAssetProvider>()));
        }

        private void EnterLoadingState()
        {
        }
    }
}