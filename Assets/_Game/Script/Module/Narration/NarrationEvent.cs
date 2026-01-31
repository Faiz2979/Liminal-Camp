using Unity.Cinemachine;
using UnityEngine;
using Yarn.Unity;

public class NarrationEvent : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _focusStateCamera;

    void Awake()
    {
        
    }

    [YarnCommand("ChangeLookAtTarget")]
    public void ChangeTarget(GameObject _target)
    {
        Debug.Log("called");
        if (_focusStateCamera == null)
        {
            Debug.LogError("CinemachineCamera not assigned");
            return;
        }

        if (_target == null)
        {
            Debug.LogError("Target GameObject not found");
            return;
        }

        _focusStateCamera.Target.TrackingTarget = _target.transform;
    }


    /*
    This is can only be applied to object that only have 1 Animation and the animation param should be
    Play: Boolean
    */
    [YarnCommand("PlayAnimation")]
    public void PlaynAnimation(GameObject _gameobject)
    {
        Animator _animator = _gameobject.GetComponent<Animator>();
        if (_animator != null)
        {
            _animator.SetBool("Play", true);
            return;
        }
        Debug.LogError("_Animator not assigned/found");
    }
}

