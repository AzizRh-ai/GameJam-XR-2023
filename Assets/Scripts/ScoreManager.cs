using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // gestion de l'instance
    public static ScoreManager instance;
    [SerializeField] private GameMenuController gameMenuController;

    private float time = 20;
    private bool timeIsRunning = false;
    private float timertick = 0f;
    int score = 0;
    int HighScore = 0;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI EndscoreText;
    [SerializeField] private TextMeshProUGUI HighScoreText;
    public AudioClip gameOverAudio;
    public AudioClip timerTickAudio;
    public AudioSource gameOverSound;
    [SerializeField] private TextMeshProUGUI StartText;
    [SerializeField] private TextMeshProUGUI StartButton;

    public void OnStartMenu(int count)
    {
        //  Texte à choisir, à changer :
        if (count == 1)
        {
            StartText.text = " You should hit everything, it's very simple.";
            StartButton.text = "Next";
        }
        else if (count == 2)
        {
            StartText.text = " However, be careful because some object..";
            StartButton.text = "Next";
        }
        else
        {
            StartText.text = "It's okay ? You can Play !";
            StartButton.text = "Play !";
        }
    }

    private void Awake()
    {
        instance = this;
        HighScore = PlayerPrefs.GetInt("HighScore");
    }
    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
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

        if (timertick <= 0 && time > 0)
        {
            gameOverSound.PlayOneShot(timerTickAudio, 0.30f);
            timertick = 1f;
            time -= 1f;

        }
        if (timeIsRunning)
        {
            time -= Time.deltaTime;

            if (time < 0)
            {
                gameOverSound.Stop();
                EndscoreText.text = "Score: " + scoreText.text;

                time = 0;
                timeIsRunning = false;
                HighScoreText.text = "HighScore: " + HighScore + " Points";
                gameOverSound.PlayOneShot(gameOverAudio);

                gameMenuController.PauseGameEnd();
            }
        }
        DisplayTime(time);
    }

    void DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = minutes + " : " + seconds;
    }

    public void AddTime(float addTime)
    {
        time += addTime;
    }
}
