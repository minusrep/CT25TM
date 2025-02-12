namespace BProject.Core
{
    public interface IState : ICanExitState
    {
        void Enter();
    }
}