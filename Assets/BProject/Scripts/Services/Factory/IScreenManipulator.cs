namespace BProject.Services
{
    public interface IScreenManipulator
    {
        void SetScreen<TView>() where TView : UIView, IScreen;
    }
}