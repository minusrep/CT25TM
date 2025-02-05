using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace BProject
{
    public class TempScript : MonoBehaviour
    {
        private VisualElement _root;
        
        private Chat _chat;
        
        [SerializeField] private UIDocument UIDocument;
        
        [SerializeField] private DialogueContainer _dialogue;

        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _root = UIDocument.rootVisualElement;
            
            _chat = new Chat(_dialogue);

            Refresh();
            
            _chat.OnChange += Refresh;
        }

        private void Refresh()
        {
            _root.Q<TextElement>("message").text = _chat.MessageText;

            var buttons = _root.Query<Button>(); 
            
            if (buttons.ToList().Any()) _root.Remove(buttons);
            
            for(int i = 0; i < _chat.Answers.Count; i++)
            {
                var button = new Button()
                {
                    text = _chat.Answers[i].PortName,
                };

                button.style.fontSize = 48f;
                
                button.clicked += () => _chat.TrySelect(i);
                
                _root.Add(button);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
