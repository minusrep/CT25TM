using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public class LevelSelectionScreen : UIView, IScreen
    {
        public void InitScreen(VisualElement root, IScreenManipulator screenManipulator)
        {
            _controller = new LevelSelectionController(root, screenManipulator);
            
            _controller.ApplySubscriptions();
        }
    }
}