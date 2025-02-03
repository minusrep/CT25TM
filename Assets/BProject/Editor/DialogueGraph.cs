using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.Editor
{
    public class DialogueGraph : EditorWindow
    {
        private DialogueGraphView _graphView;
        
        [MenuItem("Graph/Dialogue Graph")]
        public static void OpenDialogueGraphWindow()
        {
            var window = GetWindow<DialogueGraph>();
            
            window.titleContent = new GUIContent("Dialogue Graph");
        }

        private void OnEnable()
        {
            ConstructGraphView();
        }

        private void ConstructGraphView()
        {
            _graphView = new DialogueGraphView()
            {
                name = "Dialogue Graph",
            };
            
            _graphView.StretchToParentSize();
            
            rootVisualElement.Add(_graphView);
            
            GenerateToolbar();
        }

        private void GenerateToolbar()
        {
            var toolbar = new Toolbar();

            var createDialogueButton = new ToolbarButton(() => _graphView.CreateDialogueNode("Dialogue Node"))
            {
                text = "Create Node"
            };

            toolbar.Add(createDialogueButton);
            
            rootVisualElement.Add(toolbar);
        }

        
        private void OnDisable()
        {
            rootVisualElement.Remove(_graphView);
        }
    }
}
