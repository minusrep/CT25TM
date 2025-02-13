using UnityEngine.UIElements;

namespace BProject.Services
{
    public interface IScreen
    {
        void InitScreen(VisualElement root, IScreenManipulator screenManipulator);
    }
}