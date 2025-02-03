using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace BProject.Editor
{
    public class DialogueGraphView : GraphView
    {
        private const string DialogueGraph = "DialogueGraph";
        
        private readonly Vector2 _defaultNodeSize = new Vector2(240, 128);

        public DialogueGraphView()
        {
            styleSheets.Add(Resources.Load<StyleSheet>((DialogueGraph)));
            
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            
            this.AddManipulator(new ContentDragger());
            
            this.AddManipulator(new SelectionDragger());
            
            this.AddManipulator(new RectangleSelector());

            var grid = new GridBackground();
            
            Insert(0, grid);            
            
            grid.StretchToParentSize();
            
            AddElement(GenerateEntryPointNode());
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            var compatiblePorts = new List<Port>();

            ports.ForEach((port) =>
            {
                var isAnotherNode = startPort != port && startPort.node != port.node;
                
                if (isAnotherNode) compatiblePorts.Add(port);
            });

            return compatiblePorts;
        }

        private DialogueNode GenerateEntryPointNode()
        {
            var node = new DialogueNode()
            {
                title = "START",
                GUID = GUID.Generate().ToString(),
                DialogueText = "Entry Point",
                EntryPoint = true
            };
            
            node.SetPosition(new Rect(0f, 0f, 240f, 128f ));

            var generatedPort = GeneratePort(node, Direction.Output);
            
            generatedPort.portName = "Next";

            node.outputContainer.Add(generatedPort);
            
            node.RefreshExpandedState();

            node.RefreshPorts();
            
            return node;
        }

        private Port GeneratePort(DialogueNode node, Direction direction, Port.Capacity capacity = Port.Capacity.Single)
            => node.InstantiatePort(Orientation.Horizontal, direction, capacity, typeof(float));

        public DialogueNode CreateDialogueNode(string nodeName)
        {
            var dialogueNode = new DialogueNode()
            {
                title = nodeName,
                DialogueText = nodeName,
                GUID = Guid.NewGuid().ToString()
            };
            
            var inputPort = GeneratePort(dialogueNode, Direction.Input, Port.Capacity.Multi);
            
            inputPort.portName = "Input";
            
            dialogueNode.inputContainer.Add(inputPort);

            var button = new Button(() => AddChoicePort(dialogueNode))
            {
                text = "Add choice"
            };
                            
            dialogueNode.titleButtonContainer.Add(button);
            
            dialogueNode.RefreshExpandedState();
         
            dialogueNode.RefreshPorts();
            
            dialogueNode.SetPosition(new Rect(Vector2.zero, _defaultNodeSize));
            
            AddElement(dialogueNode);
            
            return dialogueNode;
        }

        private void AddChoicePort(DialogueNode dialogueNode)
        {
            var generatedPort = GeneratePort(dialogueNode, Direction.Output);

            generatedPort.portName = "New choice";
            
            dialogueNode.outputContainer.Add(generatedPort);
            
            dialogueNode.RefreshExpandedState();

            dialogueNode.RefreshPorts();
        }
    }
}
