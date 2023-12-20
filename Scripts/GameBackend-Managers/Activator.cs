using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Activator : MonoBehaviour
{
    //the puzzles that to be activated throughout the gameplay
    public GameObject puzzle0;              
    public GameObject puzzle1;
    public GameObject puzzle2;
    public TextMeshProUGUI riddle;
    //public GameObject puzzle3;

    // Start is called before the first frame update
    void Start()
    {
        //default situation - all but expect the first puzzle/marker set to non-active
        puzzle0.SetActive(false);
        puzzle1.SetActive(false);
        puzzle2.SetActive(false);
        //puzzle3.SetActive(false);
        riddle.text = "Starry-eyed, silent in the night,\nI'm not alive, but caught in light.\nSeek me out with a careful glance,"; //initial riddle 
    }

    // Update is called once per frame
    void Update()
    {
        //if the first marker for the filter is used and checked, then active the second marker and change the riddle
        if (GKBooleans.isFilterChecked)
        {
            puzzle0.SetActive(true);
            riddle.text = "Among hues of warmth, I quietly dwell,\nWith a floral companion, under a spell.\nSoft as a dream, yet frozen in time,\nSeek where symbols and echoes align.";
        }
        //if the second puzzle is solved, then active the thrid marker and change the riddle
        if (GKBooleans.isButtonSolved){
            puzzle0.SetActive(false);
            puzzle1.SetActive(true);
            riddle.text = "Within a golden hue, dreams take flight,\nA silent sentinel guards the night.\nSeek the keeper where dreams are spun,\nIn a dance of whimsy, second to none.\n\n Tic Tac Tie";
        }
        ////if the third puzzle is solved, then active the last marker and change the riddle
        if (GKBooleans.isTicTacSolved)
        {
            puzzle1.SetActive(false);
            puzzle2.SetActive(true);
            riddle.text = "Amidst the ochre peaks and skies aglow,\nA distant world where rare winds blow.\nSeek the symbol of unseen stars,\nIn the realm named for the god of wars.";
        }
    }
}
