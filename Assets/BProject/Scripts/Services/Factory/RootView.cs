using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.Services
{
    public class RootView : UIView, IScreenManipulator
    {
        private IGameFactory _factory;
        
        private VisualElement _root;

        private UIView _currentView;
        
        [SerializeField] private UIDocument _uiDocument;

        public void Construct(IGameFactory factory)
        {
            _factory = factory;
            
            _root = _uiDocument.rootVisualElement;
            
            SetScreen<SeasonsSelectionView>();
        }

        public void SetScreen<TView>() where TView : UIView, IScreen
        {
            var view = _factory.CreateUIView<TView>();
            
            ClearCurrentView();

            view.InitScreen(SetupView(view), this);            

            _currentView = view;
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
            if (_currentView == null) return;
            
            Destroy(_currentView.gameObject);

            _root.Clear();
        }
    }
}