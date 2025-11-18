using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 

    public TextMeshProUGUI scoreText; 
    private int score = 0;

    void Awake()
    {
        
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject); 
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

