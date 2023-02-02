using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // gestion de l'instance
    public static ScoreManager instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI HighScoreText;

    int score = 0;
    int HighScore = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score + " POINTS";
        HighScoreText.text = "HighScore: " + HighScore;

    }

    public void IncScore(int point)
    {
        score = score + point;
        scoreText.text = score + " POINTS";
        if (HighScore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void DecScore(int scoreValue)
    {
        score = score - scoreValue;
        scoreText.text = score + " POINTS";
    }
    // Update is called once per frame
    void Update()
    {

    }
}
