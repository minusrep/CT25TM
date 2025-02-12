namespace BProject.Core.States
{
    public class LoadingState : IPayloadState<int>
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly SceneLoader _sceneLoader;

        public LoadingState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            
            _sceneLoader = sceneLoader;
        }
        public void Enter(int levelIndex)
        {
            LoadingScreen.Show();
            
            _sceneLoader.LoadScene(SceneId.Menu, OnLoaded);
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            LoadingScreen.Hide();
        }
    }
}