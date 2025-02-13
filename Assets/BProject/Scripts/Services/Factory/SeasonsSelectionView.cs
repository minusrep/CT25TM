using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.Services
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

    public abstract class UIController
    {
        public abstract void ApplySubscriptions();
        public abstract void CancelSubscriptions();
    }
    
    public class SeasonsSelectionController : UIController
    {
        private const string SelectSeasonButton = "select-season-button";
        
        private readonly VisualElement _root;        
        
        private readonly IScreenManipulator _screenManipulator;

        private int _currentSeasonID;
        
        public SeasonsSelectionController(VisualElement root, IScreenManipulator screenManipulator)
        {
            _root = root;
            
            _screenManipulator = screenManipulator;

            _currentSeasonID = 0;
        }

        public override void ApplySubscriptions()
        {
            _root.Q<Button>(SelectSeasonButton).clicked += OnSelectButton;
        }


        public override void CancelSubscriptions()
        {
            Debug.Log("Cancel subscriptions");
            
            _root.Q<Button>(SelectSeasonButton).clicked -= OnSelectButton;
        }

        private void OnSelectButton()
        {
            Debug.Log("Select Season Button Clicked");
                
            _screenManipulator.SetScreen<DialogueSelectionView>();
        }
    }
}