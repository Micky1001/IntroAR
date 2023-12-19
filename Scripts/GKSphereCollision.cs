using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKSphereCollision : MonoBehaviour
{
    private bool isInsideBox = false;
    private float exitCooldown = 1.0f; // Adjust the cooldown duration as needed
    private float timeSinceExit = 0.0f;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("TicTacOplane"))
        {
            Debug.Log("Sphere hit the plane!");
            isInsideBox = true;
            GKBooleans.isTicTacSphere = true;
            timeSinceExit = 0.0f;
        }
    }



    void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("TicTacOplane"))
        {
            isInsideBox = false;
            Debug.Log("Sphere left the plane!");
            //GKBooleans.isTicTacSphere = false;
        }
    }


}
