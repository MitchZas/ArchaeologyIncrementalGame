using UnityEngine;
using UnityEngine.UIElements;

public class CoinCounter : MonoBehaviour
{
    [Header("Game Manager References")]
    public int score {  get; private set; }

    [Header("UI Manager References")]
    [SerializeField] private UIDocument uiDocument;
    private Label _scoreLabel;

    private void Start()
    {
        _scoreLabel = uiDocument.rootVisualElement.Q<Label>("CoinLabel");
    }
    private void OnEnable()
    {
        CoinHit.onCoinCollected += IncrementScore;
    }

    private void OnDisable()
    {
        CoinHit.onCoinCollected -= IncrementScore;
    }

    public void IncrementScore()
    {
        score++;
        _scoreLabel.text = score.ToString();
    }

   
}
