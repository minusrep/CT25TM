using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public class SeasonsSelectionScreen : UIView, IScreen
    {
        private IScreenManipulator _screenManipulator;

        public void InitScreen(VisualElement root, IScreenManipulator screenManipulator)
        {
            _controller = new SeasonsSelectionController(root, screenManipulator);
            
            _controller.ApplySubscriptions();
        }
    }
}