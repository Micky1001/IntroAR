using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GKButtonManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI RedText, GreenText, BlueText, SuccessText;
    public GameObject RedButton, GreenButton, BlueButton;
    public Camera arcam;


    private Touch touch;
    private string RedDefault, GreenDefault, BlueDefault;
    private int press = 0;
    private string hintText;
    // For now, correct order is blue, green, red

    // Start is called before the first frame update
    void Start()
    {
        RedDefault = RedText.text;
        GreenDefault = GreenText.text;
        BlueDefault = BlueText.text;
        hintText = "- - -";
        SuccessText.text = "puzzle start";

        GKBooleans.isButtonSolved = false;
        //GKBooleans.setButtonPuzzle(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
			// Get the coordinates of the center of the Button cylinder
            //Vector3 button_pos = arcam.WorldToScreenPoint(RedButton.transform.position);
			// Get touch objects
            touch = Input.GetTouch(0);
            // Declare a RaycastHit variable to store information about the collision
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            // Check if the ray hits an object with a collider
            if (Physics.Raycast(ray, out hit))
            {
                // Check for RedButton Collider
                if (hit.collider.gameObject == RedButton) {
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
