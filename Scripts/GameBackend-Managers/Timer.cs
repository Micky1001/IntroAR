using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign this in the inspector
    private float startTime;
    public static string lastTime;
    private string timeString;
    private bool isTimerRunning = false;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        timerText.text = "TIME";
        // isTimerRunning = true; // Removed this line to prevent timer from starting immediately
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GKscene") // Replace with your game scene name
        {
            StartTimer();
        }
    }

    void Update()
    {
        // Start the timer when 'K' is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartTimer();
        }

        // Stop the timer when 'J' is pressed
        //if (Input.GetKeyDown(KeyCode.J))
        if(GKBooleans.isButtonSolved && GKBooleans.isPerspSolved && GKBooleans.isTicTacSolved)
        {
            StopTimer();
        }

        if (isTimerRunning)
        {
            float timeElapsed = Time.time - startTime;
            timeString = FormatTime(timeElapsed);
            timerText.text = timeString;
        }
    }

    public void StartTimer()
    {
        if (!isTimerRunning) // Start only if the timer is not already running
        {
            startTime = Time.time;
            isTimerRunning = true;
        }
    }

    public void StopTimer()
    {
        if (isTimerRunning) // Stop only if the timer is running
        {
            isTimerRunning = false;
            lastTime = timeString;
            SceneManager.LoadScene("EndMenu");
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = (int)timeInSeconds / 60;
        int seconds = (int)timeInSeconds % 60;
        int milliseconds = (int)((timeInSeconds - (minutes * 60) - seconds) * 1000);

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public string getTime()
    {
        return lastTime;
    }
}
