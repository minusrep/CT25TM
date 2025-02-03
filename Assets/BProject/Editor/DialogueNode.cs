using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace BProject.Editor
{
    public class DialogueNode : Node
    {
        public string GUID;

        public string DialogueText;

        public bool EntryPoint = false;
    }
}
