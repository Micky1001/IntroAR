using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        //load the game scene when the player starts the game
        SceneManager.LoadScene("GKscene");  
    }

    public void QuitGame()
    {
        //quit the application when the quit is clicked
        Application.Quit();
    }
}
