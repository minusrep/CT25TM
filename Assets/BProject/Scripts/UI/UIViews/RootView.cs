using BProject.Services;
using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public class RootView : UIView, IScreenManipulator
    {
        private IGameFactory _factory;
        
        private VisualElement _root;

        private UIView _currentScreen;
        
        [SerializeField] private UIDocument _uiDocument;

        public void Construct(IGameFactory factory)
        {
            _factory = factory;
            
            _root = _uiDocument.rootVisualElement;
            
            SetScreen<SeasonsSelectionScreen>();
        }

        public void SetScreen<TView>() where TView : UIView, IScreen
        {
            var view = _factory.CreateUIView<TView>();
            
            ClearCurrentView();

            view.InitScreen(SetupView(view), this);            

            _currentScreen = view;
        }

        private VisualElement SetupView(UIView view)
        {
            var element = view.Prefab.CloneTree();

            element.style.flexGrow = 1;
            
            _root.Add(element);

            return element;
        }

        private void ClearCurrentView()
        {
            if (_currentScreen == null) return;
            
            Destroy(_currentScreen.gameObject);

            _root.Clear();
        }
    }
}