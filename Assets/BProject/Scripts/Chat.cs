using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BProject
{
    public class Chat
    {
        public event Action OnChange;
        
        public string MessageText => 
            _dialogueContainer.DialogueNodeData.First(x => x.Guid == _actualGuid).DialogueText;

        public List<NodeLinkData> Answers 
            => _dialogueContainer.NodeLinks.Where(x => x.BaseNodeGuid == _actualGuid).ToList();
        
        private DialogueContainer _dialogueContainer;

        private string _actualGuid;
        
        public Chat(DialogueContainer dialogueContainer)
        {
            _dialogueContainer = dialogueContainer;

            _actualGuid = _dialogueContainer.NodeLinks[0].TargetNodeGuid;

            OnChange?.Invoke();
        }

        public bool TrySelect(int index)
        {
            if (!Answers.Any()) return false;
            
            index = index < 0 ? 0 : index;
            
            index = index > Answers.Count - 1 ? 0 : index;

            _actualGuid = Answers[index].TargetNodeGuid;
         
            OnChange?.Invoke();
            
            return true;
        }
    }
}