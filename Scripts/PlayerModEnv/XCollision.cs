using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XCollision : MonoBehaviour
{
    // When a collision is detected
    void OnTriggerEnter(Collider other)
    {
	// When a collision is detected, check if the collision corresponds to the desired/correct TicTacGrid
	// Update each correct answer to be true once the correct collision is detected.
	// You may add more complicated conditions under each if/else if statement
        if (other.gameObject.CompareTag("TicTacXPlane1")) { GKBooleans.isgrid1 = true; Debug.Log("Cross 1"); }
        else if (other.gameObject.CompareTag("TicTacXPlane2")) { GKBooleans.isgrid2 = true; Debug.Log("Cross 2"); }
        else if (other.gameObject.CompareTag("TicTacXPlane3")) { GKBooleans.isgrid3 = true; Debug.Log("Cross 3"); }
	// Print current collision/correctness of the "X" objects to the log
        Debug.Log(GKBooleans.isgrid1 + "" + GKBooleans.isgrid2 + "" + GKBooleans.isgrid3);
    }

    private void Update()
    {
	// At every frame update evaluate whether or not every "X" has been correctly identified by the player.
	If so, update the backend game manager
        if (GKBooleans.isgrid1 && GKBooleans.isgrid2 && GKBooleans.isgrid3) { GKBooleans.isTicTacCross = true; Debug.Log("Alltrue"); }
        else { GKBooleans.isTicTacCross = false; }
    }
}
