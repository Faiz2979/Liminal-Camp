using UnityEngine;
using Yarn.Unity;

public class CallNode : MonoBehaviour
{
    private DialogueRunner _dialogueRunner;
    private void Awake()
    {
        _dialogueRunner = FindFirstObjectByType<DialogueRunner>();

        if (_dialogueRunner == null)
        {
            Debug.LogError("DialogueRunner not found in scene!");
        }
    }
    public void triggerNode(string _nodeName)
    {
        _dialogueRunner.StartDialogue(_nodeName);
    }
}
