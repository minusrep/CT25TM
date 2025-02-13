using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public class LevelSelectionController : UIController
    {
        private const string DialogueButton = "dialogue-button";

        public LevelSelectionController(VisualElement root, IScreenManipulator screenManipulator) : base(root, screenManipulator)
        {
        }

        public override void ApplySubscriptions()
        {
            _root.Q<Button>(UIConstants.HomeButton).clicked += OnHomeButton;

            Debug.Log(_root.Query<Button>(DialogueButton).First());
            
            _root.Q<Button>(DialogueButton).clicked += OnSelectDialogueButton;
        }

        public override void CancelSubscriptions()
        {
            _root.Q<Button>(UIConstants.HomeButton).clicked -= OnHomeButton;

            _root.Q<Button>(DialogueButton).clicked -= OnSelectDialogueButton;
        }

        private void OnSelectDialogueButton()
        {
            _screenManipulator.SetScreen<DialogueScreen>();
        }

        private void OnHomeButton()
        {
            _screenManipulator.SetScreen<SeasonsSelectionScreen>();
        }
    }
}