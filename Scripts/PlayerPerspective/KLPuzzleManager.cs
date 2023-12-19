using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KLPuzzleManager : MonoBehaviour
{
    public GameObject object0;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public TextMeshProUGUI positionText;
    public TMPro.TextMeshProUGUI puzzleHint;
    public Camera arcam;
    // Start is called before the first frame update
    void Start()
    {
        //positionText.text = "";
        puzzleHint.text = "A Change in Perspective";
    }

    // Update is called once per frame
    void Update()
    {
        if (!GKBooleans.isPerspSolved)
        {
            Vector3 button_pos0 = arcam.WorldToScreenPoint(object0.transform.position);
            Vector3 button_pos1 = arcam.WorldToScreenPoint(object1.transform.position);
            Vector3 button_pos2 = arcam.WorldToScreenPoint(object2.transform.position);
            Vector3 button_pos3 = arcam.WorldToScreenPoint(object3.transform.position);
            Vector3 button_pos4 = arcam.WorldToScreenPoint(object4.transform.position);

            positionText.text = "" + button_pos0+ "\n" + button_pos1 + "\n" + button_pos2 + "\n" + button_pos3 + "\n" + button_pos4;

            bool correct0 = false;
            bool correct1 = false;
            bool correct2 = false;
            bool correct3 = false;
            bool correct4 = false;

            if (button_pos0.x > 500 && button_pos0.x < 700 && button_pos0.y > 1800 && button_pos0.y < 2300)
            {
                correct0 = true;
            }
            if (button_pos1.x > 100 && button_pos1.x < 300 && button_pos1.y > 650 && button_pos1.y < 900)
            {
                correct1 = true;
            }
            if (button_pos2.x > 850 && button_pos2.x < 1100 && button_pos2.y > 650 && button_pos2.y < 900)
            {
                correct2 = true;
            }
            if (button_pos3.x > 850 && button_pos3.x < 1100 && button_pos3.y > 1400 && button_pos3.y < 1700)
            {
                correct3 = true;
            }
            if (button_pos4.x > 100 && button_pos4.x < 300 && button_pos4.y > 1400 && button_pos4.y < 1700)
            {
                correct4 = true;
            }
            if (correct0 && correct1 && correct2 && correct3 && correct4)
            {
                positionText.text = "puzzle solved!";
                puzzleHint.text = "Success";
                GKBooleans.isPerspSolved = true;
            }
        }
        

    }
}
