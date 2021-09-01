using UnityEngine;
using Yarn.Unity;

public class Speak : MonoBehaviour
{
    [SerializeField] private NPC.NPC _npc;
    [SerializeField] private DialogueRunner _dialogue;
    
    private void Start()
    {
        _dialogue = FindObjectOfType<DialogueRunner>();
    }

    public void StartSpeak()
    {
        if(CanStartConversation())
            _dialogue.StartDialogue(_npc.talkToNode);
    }
    
    private bool CanStartConversation() => !string.IsNullOrEmpty(_npc.talkToNode);
}
