using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.UI.UIViews
{
    public abstract class UIView : MonoBehaviour
    {
        public VisualTreeAsset Prefab => _prefab;

        protected UIController _controller;
        
        [SerializeField] private VisualTreeAsset _prefab;

        public virtual void Construct()
        {
            
        }

        private void OnDestroy() 
            => _controller?.CancelSubscriptions();
    }
}