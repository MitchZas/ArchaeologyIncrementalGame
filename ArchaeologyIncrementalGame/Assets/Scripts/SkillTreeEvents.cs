using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SkillTreeEvents : MonoBehaviour
{
    private UIDocument _document;

    private Button _button;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("ContinueButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnContinueClick);
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnContinueClick);
    }

    private void OnContinueClick(ClickEvent evt)
    {
        SceneManager.LoadScene(1);
        Debug.Log("I was clicked!");
    }
}
