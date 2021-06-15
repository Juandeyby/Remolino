using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] public TMP_Text timerGUI;
    [SerializeField] public TMP_Text pointsGUI;
    [HideInInspector] private GameOver _gameOver;

    [Header("Objects")]
    [SerializeField] public GameObject ball;

    [Header("Config")]
    [SerializeField] private float _ballLimit = 11f;
    [HideInInspector] public float timer;
    [HideInInspector] public float points;
    [SerializeField] public bool timerIsRunning;
    [SerializeField] public bool loading;

    private void Start()
    {
        _gameOver = FindObjectOfType<GameOver>();
        timerIsRunning = true;
    }

    private void Update()
    {
        RunTime();
        FinishGame();
    }

    private void RunTime()
    {
        RefreshTimeGUI(timer);
        if (timerIsRunning)
        {
            timer += Time.deltaTime;
        }
    }

    private void RefreshTimeGUI(float timer)
    {
        timerGUI.text = "Time: " + timerString(timer);
    }

    private void FinishGame()
    {
        if (ball)
        {
            var position = ball.transform.position;
            var limitOver = position.y > -_ballLimit;
            var limitUnder = position.y < _ballLimit;
            if (!(limitOver && limitUnder))
            {
                Destroy(ball);
                StopTimer();
                _gameOver.SetGUI();
                _gameOver.SetActive(true);
            }
        }
    }

    private void StopTimer()
    {
        timerIsRunning = false;
        SaveUserData(timer, points);
        timer = 0;
    }

    private void SaveUserData(float time, float points)
    {
        PlayerPrefs.SetFloat("timer", time);
        PlayerPrefs.SetFloat("points", points);
        if (points > PlayerPrefs.GetFloat("bestPoints"))
            PlayerPrefs.SetFloat("bestPoints", points);
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public static string timerString(float timer) {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        var timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        return timerString;
    }
}
