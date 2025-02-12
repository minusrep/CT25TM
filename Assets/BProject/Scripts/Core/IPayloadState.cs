namespace BProject.Core
{
    public interface IPayloadState<in TPayload> : ICanExitState
    {
        void Enter(TPayload payload);
    }
}