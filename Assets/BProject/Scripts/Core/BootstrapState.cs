using UnityEngine.SceneManagement;

namespace BProject.Core
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly SceneLoader _sceneLoader;
        
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            RegisterServices();
            
            _sceneLoader.LoadScene(SceneId.Initial, EnterLoadingState);
            
            _stateMachine.Enter<LoadingState, int>( 12);
        }

        private void EnterLoadingState()
        {
        }

        private void RegisterServices()
        {
        }

        public void Exit()
        {
        }
    }
}