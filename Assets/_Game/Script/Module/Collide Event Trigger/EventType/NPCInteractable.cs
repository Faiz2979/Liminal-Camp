using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string npcName = "NPC";

    public void Interact()
    {
        Debug.Log("Talk to " + npcName);
        // TODO: Trigger Dialogue
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        UIPopup.Instance.Show(
            transform,
            $"Talk to {npcName}"
        );
    }
}
