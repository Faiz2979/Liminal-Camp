using UnityEngine;
using System;

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
        this.gameObject.SetActive(false);
    }
}
