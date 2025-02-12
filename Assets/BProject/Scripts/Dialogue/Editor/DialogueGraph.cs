using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.Editor
{
    public class DialogueGraph : EditorWindow
    {
        private DialogueGraphView _graphView;

        private string _fileName = "New Dialogue";
        
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

            var fileNameTextField = new TextField("File Name");
            
            fileNameTextField.SetValueWithoutNotify(_fileName);
            
            fileNameTextField.MarkDirtyRepaint();
            
            fileNameTextField.RegisterValueChangedCallback(evt => _fileName = evt.newValue);
            
            toolbar.Add(fileNameTextField);
            
            toolbar.Add(new ToolbarButton(() => RequestDataOperation(true))
            {
                text = "Save",
            });
            
            toolbar.Add(new ToolbarButton(() => RequestDataOperation(false))
            {
                text = "Load",
            });
            
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

        private void RequestDataOperation(bool save)
        {
            if (string.IsNullOrEmpty(_fileName))
                EditorUtility.DisplayDialog("Invalid file name!", "Please enter valid file name", "OK");

            var saveUtility = GraphSaveUtility.GetInstance(_graphView);
            
            if (save)
                saveUtility.SaveGraph(_fileName);
            else
                saveUtility.LoadGraph(_fileName);
        }
    }
}
