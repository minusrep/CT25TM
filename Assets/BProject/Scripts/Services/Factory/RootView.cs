using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.Services
{
    public class RootView : UIView
    {
        private IGameFactory _factory;
        
        private VisualElement _root;

        private UIView _currentView;
        
        [SerializeField] private  UIDocument _uiDocument;

        public void Construct(IGameFactory factory)
        {
            _factory = factory;
            
            _root = _uiDocument.rootVisualElement;

            Set(_factory.CreateSeasonsView());
        }

        private void Set<TView>(TView seasonsView) where TView : UIView
        {
            ClearCurrentView();

            _currentView = seasonsView;
            
            _root.Add(seasonsView.Prefab.CloneTree());
        }

        private void ClearCurrentView()
        {
            if (_currentView == null) return;
            
            Destroy(_currentView.gameObject);

            _root.Clear();
        }
    }
}