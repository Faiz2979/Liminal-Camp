using UnityEngine;
using Yarn.Unity;

public class TorchInteractable : MonoBehaviour, IInteractable
{
    private DialogueRunner _dialogueRunner;
    [SerializeField] private string _nodeName;
    [SerializeField] private GameObject fireSprites;
    private void Awake()
    {
        _dialogueRunner = FindFirstObjectByType<DialogueRunner>();

        if (_dialogueRunner == null)
        {
            Debug.LogError("DialogueRunner not found in scene!");
        }
        fireSprites.SetActive(false);
    }
    public void Interact()
    {
        _dialogueRunner.VariableStorage.TryGetValue<bool>("$torchQuestStarted", out bool isStartQuest);
       if(isStartQuest == false){
            triggerNode("LitTorchesNotStarted");
            return;
       }
        fireSprites.SetActive(true);
        triggerNode("LitTorches");
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
