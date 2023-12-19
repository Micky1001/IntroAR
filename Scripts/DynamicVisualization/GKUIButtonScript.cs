using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GKUIButtonScript : MonoBehaviour
{
    public Button filterButton;					// public UI button we use to toggle between alternate states
    public GameObject redObject, greenObject, blueObject;	// public parent Game Object. Child objects should be loaded/unloaded simultaneously
    private bool cheked = false; 	      			// internal boolean counter to assist with updates to master backend manager, GKBooleans
    private int state = 0;					// private state counter that increments at each toggle of the filterButton

    // Start is called before the first frame update
    void Start()
    {
	// Link filterButton interactions to a specific functionality/method. In our case, this is ChangeFilter()
        filterButton.onClick.AddListener(ChangeFilter);

	// Deactivate all game objects. This is optional, but we use this in our demo to "hide" information at initialization
        redObject.SetActive(false);
        greenObject.SetActive(false);
        blueObject.SetActive(false);
    }

    // UI button interaction method. The goal of this method is to toggle active/inactive states of sets of Game Objects to visualize different information.
    void ChangeFilter()
    {
	// Display previous state information in the log
        Debug.Log(state);

	// Update state since we have observed a new call of the filterButton
        state += 1;

	// If state is beyond the range of acceptable states, reset state value to loop states
        if (state >= 4) {
            state = 0;

	    // Optional: update display of the UI button to correspond to state
            filterButton.GetComponent<Image>().color = Color.white;

	    // Deactivate all objects
            redObject.SetActive(false);
            greenObject.SetActive(false);
            blueObject.SetActive(false);
        }
	// If state == 1 == red State
        else if (state == 1) {
	    // Optional: update	display	of the UI button to correspond to state
            filterButton.GetComponent<Image>().color = Color.red;
	    // Load red Objects simultaneously
            redObject.SetActive(true);
        }
	// If state == 2 == green State
        else if (state == 2) {
	    // Optional: update	display	of the UI button to correspond to state
            filterButton.GetComponent<Image>().color = Color.green;
	    // Unload red objects simultaneously
            redObject.SetActive(false);
	    // Load green objects simultaneously
            greenObject.SetActive(true);
        }
	// If state == 3 == blue State
        else {
	    // Optional: update	display	of the UI button to correspond to state
            filterButton.GetComponent<Image>().color = Color.blue;
	    // Unload green objects simultaneously
            greenObject.SetActive(false);
	    // Load blue objects simultaneously
            blueObject.SetActive(true);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (state >= 3)
        {
            cheked = true;
        }

        if (cheked)
        {
            GKBooleans.isFilterChecked = true;
        }
    }
}
