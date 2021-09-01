using UnityEngine;
using Yarn.Unity;

namespace NPC
{
    public class NPC : MonoBehaviour
    {
        public string characterName = "";

        public string talkToNode = "";

        [Header("Optional")]
        public YarnProgram scriptToLoad;

        void Start () {
            if (scriptToLoad != null) {
                DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();
                dialogueRunner.Add(scriptToLoad);                
            }
        }
    }
}
