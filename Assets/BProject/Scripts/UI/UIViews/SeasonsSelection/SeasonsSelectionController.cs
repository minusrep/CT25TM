using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public class SeasonsSelectionController : UIController
    {
        private const string SelectSeasonButton = "select-season-button";

        private int _currentSeasonID;

        public SeasonsSelectionController(VisualElement root, IScreenManipulator screenManipulator) : base(root, screenManipulator)
        {
            _currentSeasonID = 0;
        }
        
        public override void ApplySubscriptions()
        {
            _root.Q<Button>(SelectSeasonButton).clicked += OnSelectButton;
        }

        public override void CancelSubscriptions()
        {
            _root.Q<Button>(SelectSeasonButton).clicked -= OnSelectButton;
        }

        private void OnSelectButton()
        {
            _screenManipulator.SetScreen<LevelSelectionScreen>();
        }
    }
}