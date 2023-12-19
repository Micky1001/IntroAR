using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKTicTacManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI puzzleHint;
    // Start is called before the first frame update
    void Start()
    {
        puzzleHint.text = "Tic Tac Tie";
    }

    // Update is called once per frame
    void Update()
    {
        if (GKBooleans.isTicTacSphere && GKBooleans.isTicTacCross) {
            Debug.Log("Activated test;");
            GKBooleans.isTicTacSolved = true;
            puzzleHint.text = "Success";
        }
        else {
            GKBooleans.isTicTacSolved = false;
            puzzleHint.text = "Tic Tac Tie";
        }

    }
}
