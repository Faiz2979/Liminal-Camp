using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(TriggerEvent))]
public class ChangeAreaInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform newAreaSpawnPoint;
    [SerializeField] private BoxCollider2D newAreaCollider;
    [SerializeField] private CinemachineConfiner2D confiner;
    private bool isTransitioning;

    public void Interact()
    {
        if (newAreaSpawnPoint == null)
        {
            Debug.LogWarning("New Area Spawn Point is not assigned.");
            return;
        }
        if (isTransitioning) return;
        isTransitioning = true;

        confiner.BoundingShape2D = newAreaCollider;
        UITransitionController.Instance.gameObject.SetActive(true);
        UITransitionController.Instance.PlayTransition(MovePlayer);
    }

    private void MovePlayer()
    {
        PlayerInteractor.Instance.transform.position = newAreaSpawnPoint.position;
        isTransitioning = false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (newAreaSpawnPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(newAreaSpawnPoint.position, 0.2f);
            Gizmos.DrawLine(transform.position, newAreaSpawnPoint.position);
        }
    }
#endif
}
