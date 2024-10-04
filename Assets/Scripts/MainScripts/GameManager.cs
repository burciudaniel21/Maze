using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton instance
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool gameOver;

    private void Awake()
    {
        // Ensure that there's only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (gameOver) { EndGame(); }
    }

    private void EndGame()
    {
        bool triggered = false;
        {
            if(!triggered)
            {
                gameOverText.enabled = true;
                triggered = true;
            }
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddPoint(int value)
    {
        score += value;
        Debug.Log("Current Score: " + score);
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
