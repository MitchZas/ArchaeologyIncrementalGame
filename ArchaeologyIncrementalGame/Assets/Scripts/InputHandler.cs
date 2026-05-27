using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    public bool isClicked;

    [Header("Auto Click Settings")]
    public bool autoClick = false;
    public float autoClickInterval = 1f;
    private float _autoClickTimer;

    private void Awake()
    {
        _mainCamera = Camera.main;
        isClicked = false;
        _autoClickTimer = autoClickInterval;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        isClicked = true;
        if (!context.started) return;
        PerformClick();
    }

    void Update()
    {
        if (autoClick)
        {
            _autoClickTimer -= Time.deltaTime;
            if (_autoClickTimer <= 0f)
            {
                _autoClickTimer = autoClickInterval;
                Debug.Log(autoClickInterval);
            }
        }
    }
    private void PerformClick()
    {
        var rayhit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayhit.collider) return;
        //Debug.Log(rayhit.collider.gameObject.name);
    }
}
