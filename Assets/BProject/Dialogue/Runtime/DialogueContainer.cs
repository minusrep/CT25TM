﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace BProject
{
    [Serializable]
    public class DialogueContainer : ScriptableObject
    {
        public List<DialogueNodeData> DialogueNodeData = new List<DialogueNodeData>();
        
        public List<NodeLinkData> NodeLinks = new List<NodeLinkData>();
    }
}