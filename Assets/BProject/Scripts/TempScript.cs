using UnityEngine;
using UnityEngine.UIElements;

namespace BProject
{
    public class TempScript : MonoBehaviour
    {
        [SerializeField] private UIDocument UIDocument;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Debug.Log(UIDocument.rootVisualElement.name);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
