using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GKButtonTouchScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI phaseDisplayText;
    public GameObject Button;
    public Camera arcam;
    private Touch touch;
    private string defaultText;

    // Start is called before the first frame update
    void Start()
    {
        defaultText = phaseDisplayText.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
			// Get the coordinates of the center of the Button cylinder
            Vector3 button_pos = arcam.WorldToScreenPoint(Button.transform.position);
			
			
			// Here is where we'd do more stuff
			// Get touch objects
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            // vector2 world_pos=arcam.main.ScreenToWorldPoint(touch.position); //TODO: Check if that's the right conversion/datatype


            // Declare a RaycastHit variable to store information about the collision
            RaycastHit hit;

            // Check if the ray hits an object with a collider
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the collider belongs to the object you are interested in
                if (hit.collider.gameObject == Button)
                {
                    phaseDisplayText.text = defaultText + "True";
                    // Perform any additional actions you want here
                    // For example, you can call a method on the object or change its color
                }
                else
                {
                    phaseDisplayText.text = defaultText + "False, Wrong Touch";
                }
            }
            else
            {
                phaseDisplayText.text = defaultText + "False, Wrong Touch";
            }
       

        }
        else
        {
            phaseDisplayText.text = defaultText + "False, No Touch";
        }

    }
}
