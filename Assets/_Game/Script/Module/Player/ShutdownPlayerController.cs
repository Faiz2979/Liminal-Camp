using UnityEngine;
using UnityEngine.InputSystem;
using Service.PlayerController;
using Yarn.Unity;
using Unity.VisualScripting;

public class ShutdownPlayerController : MonoBehaviour
{

    [SerializeField] private PlayerController _playerController;

    [YarnCommand("DisableController")]
    public void DisablePlayerController()
    {
        _playerController.enabled = false;
    }
    
    [YarnCommand("EnableController")]
    public void EnablePlayerController()
    {
        _playerController.enabled = true;
    }
    
}
