namespace BProject.Core.States
{
    public interface IState : ICanExitState
    {
        void Enter();
    }
}