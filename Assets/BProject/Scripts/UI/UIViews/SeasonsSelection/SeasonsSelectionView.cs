using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public class SeasonsSelectionView : UIView, IScreen
    {
        private SeasonsSelectionController _controller;
        
        private IScreenManipulator _screenManipulator;

        public void InitScreen(VisualElement root, IScreenManipulator screenManipulator)
        {
            _controller = new SeasonsSelectionController(root, screenManipulator);
            
            _controller.ApplySubscriptions();
        }

        private void OnDestroy()
        {
            _controller.CancelSubscriptions();
        }
    }
}