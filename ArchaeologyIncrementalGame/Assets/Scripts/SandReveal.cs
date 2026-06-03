using UnityEngine;
using UnityEngine.Rendering;

public class SandReveal : MonoBehaviour
{
    public GameObject MaskPrefab;
    [SerializeField] InputHandler inputHandlerScript;

    [Header("Mask Prefab Rotation")]
    private float maskX = 0f;
    private float maskY = 0f;
    private float maskZ = 140f;

    void OnEnable()
    {
        inputHandlerScript.OnClickPerformed += HandleClick;
    }

    void OnDisable()
    {
        inputHandlerScript.OnClickPerformed -= HandleClick;
    }

    private void HandleClick(Vector2 screenPosition)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(screenPosition);
        mousePos.z = 5;
        GameObject MaskSprite = Instantiate(MaskPrefab, mousePos, Quaternion.Euler(maskX, maskY, maskZ));
        MaskSprite.transform.parent = gameObject.transform;
    }
}
