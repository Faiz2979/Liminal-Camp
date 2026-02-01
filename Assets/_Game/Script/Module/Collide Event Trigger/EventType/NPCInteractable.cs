using UnityEngine;
using Yarn.Unity;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    private DialogueRunner _dialogueRunner;
    [SerializeField] private string _nodeName;
    private void Awake()
    {
        _dialogueRunner = FindFirstObjectByType<DialogueRunner>();

        if (_dialogueRunner == null)
        {
            Debug.LogError("DialogueRunner not found in scene!");
        }
    }
    public void Interact()
    {
        triggerNode(this._nodeName);
        PlayerInteractor.Instance.ClearInteractable();
    }

    public async void triggerNode(string _nodeName)
    {
        await _dialogueRunner.StartDialogue(_nodeName);
    }
}
