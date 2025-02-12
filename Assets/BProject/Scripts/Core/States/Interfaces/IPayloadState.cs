namespace BProject.Core.States
{
    public interface IPayloadState<in TPayload> : ICanExitState
    {
        void Enter(TPayload payload);
    }
}