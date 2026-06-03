using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    public event System.Action<Vector2> OnClickPerformed;

    [Header("Auto Click Settings")]
    public bool autoClick = false;
    public float autoClickInterval = 1f;
    private float _autoClickTimer;

    [Header("SFX")]
    [SerializeField] private AudioSource sweepSFX;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _autoClickTimer = autoClickInterval;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
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
                Vector2 mousePos = Mouse.current.position.ReadValue();
                OnClickPerformed?.Invoke(mousePos);
                sweepSFX.Play();
                PerformClick();
            }
        }
    }
    public void PerformClick()
    {
        var rayhit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayhit.collider) return;

        Debug.Log(rayhit.collider.gameObject.name);

        if (rayhit)
        {
            IClickable clickable = rayhit.collider.GetComponent<IClickable>();
            if (clickable != null)
            {
                clickable.OnClick();
            }
        }
    }
}
