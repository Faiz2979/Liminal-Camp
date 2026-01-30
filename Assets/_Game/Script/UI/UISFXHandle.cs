using Unity.VisualScripting;
using UnityEngine;

public class UISFXHandle : MonoBehaviour
{
    public void PlaySFX(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

}
