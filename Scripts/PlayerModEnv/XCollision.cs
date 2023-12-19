using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TicTacXPlane1")) { GKBooleans.isgrid1 = true; Debug.Log("Cross 1"); }
        else if (other.gameObject.CompareTag("TicTacXPlane2")) { GKBooleans.isgrid2 = true; Debug.Log("Cross 2"); }
        else if (other.gameObject.CompareTag("TicTacXPlane3")) { GKBooleans.isgrid3 = true; Debug.Log("Cross 3"); }
        Debug.Log(GKBooleans.isgrid1 + "" + GKBooleans.isgrid2 + "" + GKBooleans.isgrid3);
    }


    private void OnTriggerExit(Collider other)
    {
        //if(other.gameObject.CompareTag("TicTacXPlane1")) { grid1 = false; }
        //else if (other.gameObject.CompareTag("TicTacXPlane2")) { grid2 = false; }
        //else if (other.gameObject.CompareTag("TicTacXPlane3")) { grid3 = false; }
    }

    private void Update()
    {
        if (GKBooleans.isgrid1 && GKBooleans.isgrid2 && GKBooleans.isgrid3) { GKBooleans.isTicTacCross = true; Debug.Log("Alltrue"); }
        else { GKBooleans.isTicTacCross = false; }
    }
}
