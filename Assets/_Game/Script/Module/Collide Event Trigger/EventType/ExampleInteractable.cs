using UnityEngine;

public class ExampleInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("ExampleInteractable has been interacted with!");
    }
}