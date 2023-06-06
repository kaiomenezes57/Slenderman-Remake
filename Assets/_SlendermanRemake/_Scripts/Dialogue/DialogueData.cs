using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace SlendermanRemake.Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue")]
    public class DialogueData : ScriptableObject
    {
        public List<string> DialogueBody = new();
        public UnityEvent UnityEvent;

        public string GetNextMessage(int index)
        {
            return DialogueBody[index];
        }

        public bool CheckNextDialogueExists(int index)
        {
            return index < DialogueBody.Count;
        }
    }
}