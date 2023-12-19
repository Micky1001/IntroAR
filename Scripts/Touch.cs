using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For Text Mesh Pro

public class TouchScript : MonoBehaviour
{
    public TextMeshProUGUI phaseDisplayText;
    public GameObject Button; // Ensure this is the button you want to interact with
    public Camera arcam; // Reference to the AR camera
    private float displayTime = 2.0f; // Duration to display the text

    void Start()
    {
        // Initialize text to be empty
        phaseDisplayText.text = "";
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arcam.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "interact")
                    {
                        phaseDisplayText.text = "Button Touched";
                        StartCoroutine(HideTextAfterDelay(displayTime));
                    }
                }
            }
        }
    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        phaseDisplayText.text = ""; // Clear the text
    }
}



