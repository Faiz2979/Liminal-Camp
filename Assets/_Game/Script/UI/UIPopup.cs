using UnityEngine;
using TMPro;

public class UIPopup : MonoBehaviour
{
    public static UIPopup Instance;

    [SerializeField] private GameObject popupObject;
    [SerializeField] private RectTransform popupRect;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Camera worldCamera;
    [SerializeField] private TextMeshProUGUI popupText;

    [SerializeField] private Vector3 worldOffset = Vector3.up;

    private Transform target;

    private void Awake()
    {
        Instance = this;
        popupObject.SetActive(false);

        if (worldCamera == null)
            worldCamera = Camera.main;
    }

    private void Update()
    {
        if (target == null) return;

        Vector3 worldPos = target.position + worldOffset;
        Vector3 screenPos = worldCamera.WorldToScreenPoint(worldPos);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            screenPos,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : worldCamera,
            out Vector2 localPoint
        );

        popupRect.localPosition = localPoint;
    }

    public void Show(Transform targetTransform, string text)
    {
        target = targetTransform;
        popupText.text = text;
        popupObject.SetActive(true);
    }

    public void Hide()
    {
        target = null;
        popupObject.SetActive(false);
    }
}
