using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class Boot : MonoBehaviour
{
    [YarnCommand("ChangeScene")]
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
