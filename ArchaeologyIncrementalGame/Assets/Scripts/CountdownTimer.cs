using UnityEngine;
using UnityEngine.UIElements;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private float startTime = 15f;

    private Label _timerLabel;
    private float _currentTime;
    private bool isRunning = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentTime = startTime;
        isRunning = true;
        _timerLabel = uiDocument.rootVisualElement.Q<Label>("TimerLabel");
        UpdateTimerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning) return;

        _currentTime -= Time.deltaTime;
        //Debug.Log(_currentTime);

        if (_currentTime <= 0)
        {
            _currentTime = 0;
            isRunning = false;
        }
            
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int seconds = Mathf.FloorToInt(_currentTime);
        int milliseconds = Mathf.FloorToInt((_currentTime % 1) * 100);
        _timerLabel.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);

        if (_currentTime <=5)
        {
            _timerLabel.style.color = Color.red;
        }
        else if (_currentTime <=10)
        {
            _timerLabel.style.color = Color.yellow;
        }
        else
        {
            _timerLabel.style.color = Color.white;
        }
    }
}
