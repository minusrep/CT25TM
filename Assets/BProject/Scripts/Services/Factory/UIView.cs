using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.Services
{
    public abstract class UIView : MonoBehaviour
    {
        public VisualTreeAsset Prefab => _prefab;
        
        [SerializeField] private VisualTreeAsset _prefab;

        public virtual void Construct()
        {
            
        }
    }
}