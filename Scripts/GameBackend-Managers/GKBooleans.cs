using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKBooleans : MonoBehaviour
{
    private static bool checkFilter = false;
    private static bool buttonPuzzle = false;
    private static bool ticTacPuzzle = false;
    private static bool ticTacCross, ticTacSphere = false;
    private static bool grid1, grid2, grid3 = false;
    private static bool perspectivePuzzle = false;

    // Handle toggle for Puzzle 1
    public static bool isButtonSolved
    {
        get { return buttonPuzzle; }
        set { buttonPuzzle = value; }
    }

    // Handle toggle for Puzzle 2
    public static bool isTicTacSolved
    {
        get { return ticTacPuzzle; }
        set { ticTacPuzzle = value; }
    }

    // Handle toggle for Puzzle 2 cross
    public static bool isTicTacCross
    {
        get { return ticTacCross; }
        set { ticTacCross = value; }
    }

    public static bool isgrid1
    {
        get { return grid1; }
        set { grid1 = value; }
    }

    public static bool isgrid2
    {
        get { return grid2; }
        set { grid2 = value; }
    }

    public static bool isgrid3
    {
        get { return grid3; }
        set { grid3 = value; }
    }

    // Handle toggle for Puzzle 2 spheres
    public static bool isTicTacSphere
    {
        get { return ticTacSphere; }
        set { ticTacSphere = value; }
    }

    // Handle toggle for Puzzle 3
    public static bool isPerspSolved
    {
        get { return perspectivePuzzle; }
        set { perspectivePuzzle = value; }
    }

    public static bool isFilterChecked
    {
        get { return checkFilter; }
        set { checkFilter = value; }
    }
}
