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

		    // Evaluate if the red button was pressed at the correct sequence order using press.
		    // If correct, updates debugging texts and game state solved (GKBooleans.isButtonSolved) appropriately
                    if (press == 2) { press = 3; GKBooleans.isButtonSolved = true; hintText = "Success: X X X"; SuccessText.text = "Success: X X X"; }
		    // Else, resets sequence value and debugging texts
                    else if (press != 3) { press = 0; hintText = "_ _ _"; SuccessText.text = hintText; }
                }
                
                // Check for GreenButton Collidder
                else if (hit.collider.gameObject == GreenButton) {
		    // State GreenButton collision was detected if using GreenText for debugging purposes
                    GreenText.text = GreenDefault + "True";

		    // Evaluate	if the green button was pressed at the correct sequence order using press.
		    // If correct, updates debugging texts and sequence index, press.
                    if (press == 1) { press += 1; hintText = "X X _"; SuccessText.text = hintText; }
		    // Else, resets sequence value and debugging texts
                    else if(press != 2) { press = 0; hintText = "_ _ _"; SuccessText.text = hintText; }
                }

                // Check for BlueButton Collider
                else if (hit.collider.gameObject == BlueButton) {
		    // State BlueButton collision was detected if using BlueText for debugging purposes
                    BlueText.text = BlueDefault + "True";

		    // Evaluate if the blue button was pressed at the correct sequence order using press.
		    // If correct, updates debugging texts and sequence	index, press.
                    if (press == 0) { press += 1; hintText = "X _ _"; SuccessText.text = hintText; }
		    // Else, resets sequence value and debugging texts
                    else if (press != 1) { press = 0; hintText = "_ _ _";  SuccessText.text = hintText; }
                }

                // Else, you did not correctly touch any button and game state does not advance.
		// AN additional penalty/restriction could be implemented into the below else statement, but we choose to merely reconfirm the SuccessText display.
		// An example penalty could occur whenever you touch an unrelated game object.
                else {
                    if (GKBooleans.isButtonSolved) { SuccessText.text = "Success: X X X"; }
                    else { SuccessText.text = hintText; }
                }
            }
	    // Else, the ray did not touch anything and game state does not advance.
	    // An additional penalty/restriction could be implemented into the below else statement, but we choose to merely reconfirm the SuccessText display
	    // An example metric (either for scoring or restriction) could be counting number of touches used to complete the escape room, which would require incrementing of some counter even if the ray misses.
            else
            {
                if (GKBooleans.isButtonSolved) { RedText.text = "Success: X X X"; }
                else { RedText.text = hintText; }
            }
       
        }
	// Else, no touch was detected and game state does not advanace.
	// An additional penalty/restriction could be implemented into the below else statement, but we choose to merely reconfirm the SuccessText display.
	// An example penalty could include a counter that incurs some game state change if no touches are detected for a large period of time
        else
        {
            if (GKBooleans.isButtonSolved) { RedText.text = "Success: X X X"; }
            else { RedText.text = hintText; }
        }

    }
}
