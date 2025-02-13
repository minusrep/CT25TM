using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public abstract class UIController
    {
        protected VisualElement _root;
        
        protected IScreenManipulator _screenManipulator;

        protected UIController(VisualElement root, IScreenManipulator screenManipulator)
        {
            _root = root;
            
            _screenManipulator = screenManipulator;
        }

        public abstract void ApplySubscriptions();
        public abstract void CancelSubscriptions();
    }
}