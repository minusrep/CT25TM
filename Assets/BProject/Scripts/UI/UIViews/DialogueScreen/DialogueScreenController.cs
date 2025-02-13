using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public class DialogueScreenController : UIController
    {
        public DialogueScreenController(VisualElement root, IScreenManipulator screenManipulator) : base(root, screenManipulator)
        {
            
        }

        public override void ApplySubscriptions()
        {
            _root.Q<Button>(UIConstants.HomeButton).clicked += OnHomeButton;               
        }

        public override void CancelSubscriptions()
        {
            _root.Q<Button>(UIConstants.HomeButton).clicked -= OnHomeButton;               
        }

        private void OnHomeButton()
        {
            _screenManipulator.SetScreen<LevelSelectionScreen>();
        }
    }
}