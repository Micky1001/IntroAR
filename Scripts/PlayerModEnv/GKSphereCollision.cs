using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKSphereCollision : MonoBehaviour
{
    // When Collision occurs
    void OnTriggerEnter(Collider other)
    {
	// Sample Debug statement to evaluate whether or not the sphere object collider has been successfully initialized
	Debug.Log("Sphere Object Collision identified")
	// When a collision is detected, check if the collision corresponds to the desired/correct TicTacGrid
	// Update each correct answer to be true once the correct collision is detected.
	// You may add more complicated conditions under each if/else if statement
        if (other.gameObject.CompareTag("TicTacOplane"))
        {
	    // Sample Debug statement toe valuate whether or not the Tic Tac Grid collider/tag has been correctly initialized
            Debug.Log("Sphere hit the plane!");
	    // Adjust game state to account for correct GKBoolenas
            GKBooleans.isTicTacSphere = true;
        }
    }

}
