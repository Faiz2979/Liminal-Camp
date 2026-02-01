using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class Boot : MonoBehaviour
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

    [YarnCommand("ChangeScene")]
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Prologue()
    {
        if (_dialogueRunner == null)
        {
            Debug.LogError("DialogueRunner not found!");
            return;
        }

        _dialogueRunner.StartDialogue("Prologue");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
