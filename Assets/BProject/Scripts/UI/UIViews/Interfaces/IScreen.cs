using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public interface IScreen
    {
        void InitScreen(VisualElement root, IScreenManipulator screenManipulator);
    }
}