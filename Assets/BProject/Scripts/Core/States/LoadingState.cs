using BProject.Services;

namespace BProject.Core.States
{
    public class LoadingState : IPayloadState<int>
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly SceneLoader _sceneLoader;
        
        private readonly IGameFactory _gameFactory;

        public LoadingState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            
            _sceneLoader = sceneLoader;
            
            _gameFactory = gameFactory;
        }
        public void Enter(int levelIndex)
        {
            LoadingScreen.Show();
            
            _sceneLoader.LoadScene(SceneId.Menu, OnLoaded);
        }

        private void OnLoaded()
        {
            _gameFactory.CreateRootView();
            
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            LoadingScreen.Hide();
        }
    }
}