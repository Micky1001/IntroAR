using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // shows the time used during the gameplay    
    private float startTime;         //starting time of the timer
    public static string lastTime;   //lasting time of the timer
    private string timeString;      //string used to display
    private bool isTimerRunning = false;    //boolean that controls the timer


    //scene management 
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
        //display TIME text 
        timerText.text = "TIME";
        // isTimerRunning = true; // Removed this line to prevent timer from starting immediately
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //start the timer when the game scene starts
        if (scene.name == "GKscene") // Replace with your game scene name
        {
            StartTimer();
        }
    }

    void Update()
    {
        //if all puzzles are solved call StopTimer()
        if(GKBooleans.isButtonSolved && GKBooleans.isPerspSolved && GKBooleans.isTicTacSolved)
        {
            StopTimer();
        }

        //let the timer count the time
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

    //format the timer for display
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
