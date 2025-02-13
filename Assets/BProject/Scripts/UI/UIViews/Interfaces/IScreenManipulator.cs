namespace BProject.UI.UIViews
{
    public interface IScreenManipulator
    {
        void SetScreen<TView>() where TView : UIView, IScreen;
    }
}