using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Yarn.Unity;

public class NarrationEvent : MonoBehaviour
{
    [SerializeField] private CinemachineConfiner2D confiner;
    [SerializeField] private CinemachineCamera _focusStateCamera;

    [SerializeField] private GameObject _title;
    [SerializeField] private GameObject _maskItem;
    [SerializeField] private GameObject _searchMaskQuest;


    [YarnCommand("EnableSearchMaskQuest")]
    public void EnableSearchMaskQuest()
    {
        if (_searchMaskQuest != null)
        {
            _searchMaskQuest.SetActive(true);
        }
        else
        {
            Debug.LogError("_searchMaskQuest not assigned");
        }
    }
    [YarnCommand("ChangeLookAtTarget")]
    public void ChangeTarget(GameObject _target)
    {
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


    [YarnCommand("MoveCharacter")]
    public void MoveCharacter(GameObject _character, GameObject _newPosition)
    {
        if (_character != null)
        {
            _character.transform.position = _newPosition.transform.position;
            return;
        }
        Debug.LogError("_character not assigned/found");
    }
    /*
    This is can only be applied to object that only have 1 Animation and the animation param should be
    Play: Boolean
    */
    [YarnCommand("PlayAnimation")]
    public void PlayAnimation(GameObject _gameobject)
    {
        Animator _animator = _gameobject.GetComponent<Animator>();
        if (_animator != null)
        {
            _animator.SetBool("Play", true);
            return;
        }
        Debug.LogError("_Animator not assigned/found");
    }

    [YarnCommand("IncreaseLightRadius")]
    public void IncreaseLightRadius(GameObject _lightObject)
    {
        Light2D light = _lightObject.GetComponent<Light2D>();
        if (light != null)
        {
            light.pointLightOuterRadius += 4.0f;
            light.pointLightInnerRadius += 2.0f;
            light.color = Color.yellow;
            return;
        }
        Debug.LogError("Light2D not assigned/found");
    }

    [YarnCommand("ChangeLayerOrder")]
    public void ChangeLayerOrder(GameObject _gameobject, int _order)
    {
        SpriteRenderer spriteRenderer = _gameobject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = _order;
            return;
        }
        Debug.LogError("SpriteRenderer not assigned/found");
    }

    [YarnCommand("GameObjectState")]
    public void SetGameObjectState(string _objectName, bool _state)
    {
        if (_objectName == _maskItem.name)
        {
            _maskItem.SetActive(_state);
        }
        else if (_objectName == _title.name)
        {
            _title.SetActive(_state);
        }
    }

    [YarnCommand("SetPlayerPosition")]
    public void SetPlayerPosition(GameObject _target, float _offsetX)
    {
        PlayerInteractor.Instance.transform.position = _target.transform.position+ new Vector3(_offsetX,0f, 0);
    }

}

