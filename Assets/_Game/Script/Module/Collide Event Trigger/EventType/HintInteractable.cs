using UnityEngine;
using Yarn.Unity;

public class HintInteractable : MonoBehaviour, IInteractable
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
        triggerNode("FindMaskSearch");
        this.gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

    }
    public async void triggerNode(string _nodeName)
    {
        await _dialogueRunner.StartDialogue(_nodeName);
    }
}
