using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
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

        public void AddChoicePort(DialogueNode dialogueNode, string choicePortName = "New choice")
        {
            var generatedPort = GeneratePort(dialogueNode, Direction.Output);

            generatedPort.portName = choicePortName;

            var textField = new TextField()
            {
                name = string.Empty,
                value = choicePortName,
            };

            textField.RegisterValueChangedCallback(evt => generatedPort.portName = evt.newValue);    
            
            var deleteButton = new Button(() => RemovePort(dialogueNode, generatedPort))
            {
                text = "X"
            };
            
            generatedPort.contentContainer.Add(textField);

            generatedPort.contentContainer.Add(deleteButton);
            
            dialogueNode.outputContainer.Add(generatedPort);
            
            dialogueNode.RefreshExpandedState();

            dialogueNode.RefreshPorts();
        }

        private void RemovePort(DialogueNode dialogueNode, Port generatedPort)
        {
            var targetEdge = edges.ToList().Where(x =>
                x.output.portName == generatedPort.portName && x.output.node == generatedPort.node);

            if (targetEdge.Any())
            {
                var edge = targetEdge.First();
            
                edge.input.Disconnect(edge);
            
                RemoveElement(targetEdge.First());
            }
            dialogueNode.outputContainer.Remove(generatedPort);

            dialogueNode.RefreshPorts();
            
            dialogueNode.RefreshExpandedState();
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
            
            node.SetPosition(new Rect(128f, 128f, 240f, 128f ));

            node.capabilities &= ~Capabilities.Deletable;
            
            node.capabilities &= ~Capabilities.Movable;
            
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
            
            dialogueNode.styleSheets.Add(Resources.Load<StyleSheet>("DialogueNode"));
            
            var inputPort = GeneratePort(dialogueNode, Direction.Input, Port.Capacity.Multi);
            
            inputPort.portName = "Input";
            
            dialogueNode.inputContainer.Add(inputPort);

            var button = new Button(() => AddChoicePort(dialogueNode))
            {
                text = "Add choice"
            };
                            
            dialogueNode.titleButtonContainer.Add(button);

            var textField = new TextField(string.Empty);

            textField.RegisterValueChangedCallback(evt =>
            {
                dialogueNode.title = evt.newValue;
                dialogueNode.DialogueText = evt.newValue;
            });
            
            textField.SetValueWithoutNotify(dialogueNode.title);
            
            dialogueNode.mainContainer.Add(textField);
            
            dialogueNode.RefreshExpandedState();
         
            dialogueNode.RefreshPorts();
            
            dialogueNode.SetPosition(new Rect(Vector2.zero, _defaultNodeSize));
            
            AddElement(dialogueNode);
            
            return dialogueNode;
        }
    }
}
