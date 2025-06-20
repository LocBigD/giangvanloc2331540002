using UnityEngine;
using UnityEngine.UI; // 👈 Cần thiết để dùng Text
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Components")]
    [SerializeField] private Text scoreText; // Dùng UI Text thường
    [SerializeField] private GameObject gameOverPanel;

    [Header("Game Stats")]
    private long currentScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentScore = 0;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString("N0");
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned in Inspector.");
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
