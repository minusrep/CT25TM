using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public class DialogueScreen : UIView, IScreen
    {
        public void InitScreen(VisualElement root, IScreenManipulator screenManipulator)
        {
            _controller = new DialogueScreenController(root, screenManipulator);
            
            _controller.ApplySubscriptions();
        }
    }
}