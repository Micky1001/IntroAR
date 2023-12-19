using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndSceneManager : MonoBehaviour
{
    //public GameTimer gameTimer;
    
    public TextMeshProUGUI timeRecordText;
    // Start is called before the first frame update
    void Start()
    {
        timeRecordText.text = GameTimer.lastTime;
    }

    
}
