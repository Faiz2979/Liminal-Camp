using UnityEngine;
using System;
using Yarn.Unity;

public class UITransitionController : MonoBehaviour
{
    public static UITransitionController Instance;

    private Action onTransitionComplete;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayTransition(Action onComplete)
    {
        onTransitionComplete = onComplete;
        GetComponent<Animator>().SetTrigger("StartTransition");
    }

    public void AnimationEvent_Complete()
    {
        onTransitionComplete?.Invoke();
        onTransitionComplete = null;    
    }

    [YarnCommand("PlayTransition")]
    public void Yarn_PlayTransition()
    {
        gameObject.SetActive(true);
        PlayTransition(null);
    }
}
