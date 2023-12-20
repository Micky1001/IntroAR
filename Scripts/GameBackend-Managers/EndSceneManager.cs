using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndSceneManager : MonoBehaviour
{
    
    
    public TextMeshProUGUI timeRecordText;
    // Start is called before the first frame update
    void Start()
    {
        //displat the time record from the last gameplay
        timeRecordText.text = GameTimer.lastTime;
    }

    
}
