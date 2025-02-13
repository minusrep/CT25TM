using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.Services
{
    public class DialogueSelectionView : UIView, IScreen
    {
        public void InitScreen(VisualElement root, IScreenManipulator screenManipulator)
        {
            Debug.Log("Init Dialogue Selection View");
        }
    }
}