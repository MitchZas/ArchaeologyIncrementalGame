using UnityEngine;

public class SandReveal : MonoBehaviour
{
    public GameObject MaskPrefab;
    [SerializeField] InputHandler inputHandlerScript;

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
        GameObject MaskSprite = Instantiate(MaskPrefab, mousePos, Quaternion.identity);
        MaskSprite.transform.parent = gameObject.transform;
    }


}
