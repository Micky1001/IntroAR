using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GKButtonManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI RedText, GreenText, BlueText;		// Public UI text objects used for debugging raycast to button
    public TMPro.TextMeshProUGUI SuccessText;	     			// Public UI text objects used for debugging sequence completion
    public GameObject RedButton, GreenButton, BlueButton;		// Public game objects used as buttons for the sequence
    public Camera arcam;	 	      				// AR camera


    private Touch touch;						// Unity.Touch structure to store interaction screen pos
    private string RedDefault, GreenDefault, BlueDefault;		// Corresponding default text strings for the debbugging text objects
    private int press = 0;     		     				// Index of the current sequency entry
    private string hintText;						// Internal boolean that stores the current progression of the sequence (and if it's correct or not). Corresponds to SuccessText debugging object

    // For now, correct order is blue, green, red
    // Start is called before the first frame update
    void Start()
    {
	// Save the default text entries in order to reset text information when the incorrect sequence is input
        RedDefault = RedText.text;
        GreenDefault = GreenText.text;
        BlueDefault = BlueText.text;
        hintText = "- - -";
        SuccessText.text = "Puzzle Start";

	// Initialize completion boolean to false for game backend management
        GKBooleans.isButtonSolved = false;

    }

    // Update is called once per frame
    void Update()
    {
	// Check if a touch has been detected on the touch screen
        if (Input.touchCount > 0)
        {
	    // If so, store the touch value
            touch = Input.GetTouch(0);
            // Declare a RaycastHit variable to store 2D touch information as a ray
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            // Check if the ray hits an object with a collider
            if (Physics.Raycast(ray, out hit))
            {
                // Check for RedButton Collider
                if (hit.collider.gameObject == RedButton) {
		    // State RedButton collision was detected if using RedText for debugging purposes
		    RedText.text = RedDefault + "True";
                    if (press == 2) { press = 3;  SuccessText.text = "Success"; GKBooleans.isButtonSolved = true; hintText = "Success: X X X"; RedText.text = "Success: X X X"; }
                    else if (press != 3) { press = 0; SuccessText.text = "Fail"; hintText = "_ _ _"; RedText.text = hintText; }
                }
                
                // Check for GreenButton Collidder
                else if (hit.collider.gameObject == GreenButton) {
                    GreenText.text = GreenDefault + "True";
                    if (press == 1) { press += 1; SuccessText.text = "X X _ "; hintText = "X X _"; RedText.text = hintText; }
                    else if(press != 2) { press = 0; SuccessText.text = "Fail"; hintText = "_ _ _"; RedText.text = hintText; }
                }

                // Check for BlueButton Collider
                else if (hit.collider.gameObject == BlueButton) {
                    BlueText.text = BlueDefault + "True";
                    if (press == 0) { press += 1; SuccessText.text = " X _ _"; hintText = "X _ _"; RedText.text = hintText; }
                    else if (press != 1) { press = 0; SuccessText.text = "Fail"; hintText = "_ _ _";  RedText.text = hintText; }
                }

                // Else, you did not correctly touch the button
                else {
                    if (GKBooleans.isButtonSolved) { RedText.text = "Success: X X X"; }
                    else { RedText.text = hintText; }
                }
            }
            else
            {
                if (GKBooleans.isButtonSolved) { RedText.text = "Success: X X X"; }
                else { RedText.text = hintText; }
            }
       
        }
        else
        {
            if (GKBooleans.isButtonSolved) { RedText.text = "Success: X X X"; }
            else { RedText.text = hintText; }
        }

    }
}
