using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance

    public TextMeshProUGUI scoreText; // Drag your TMP UI Text here
    private int score = 0;

    void Awake()
    {
        // Set the singleton instance
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject); // only one instance allowed
    }

    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
