using UnityEngine;
using UnityEngine.UIElements;

namespace BProject
{
    public class LoadingScreen : MonoBehaviour
    {
        private static LoadingScreen Instance
            => _instance ?? Instantiate(Resources.Load<LoadingScreen>("LoadingScreen"));

        private static LoadingScreen _instance;
        
        public UIDocument UIDocument;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }
        
        public static void Show()
        {
            if (Instance == null) return;

            Instance.UIDocument.rootVisualElement.style.display = DisplayStyle.None;
            
            Debug.Log($"{nameof(LoadingScreen)}: Show");
        }

        public static void Hide()
        { 
            if(Instance != null) 
                Instance.UIDocument.rootVisualElement.style.display = DisplayStyle.None;

            Debug.Log($"{nameof(LoadingScreen)}: Hide");
        }
    }
}