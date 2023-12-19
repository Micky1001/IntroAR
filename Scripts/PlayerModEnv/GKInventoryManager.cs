using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GKInventoryManager : MonoBehaviour
{
    public Button InventoryButton;					// UI button used to toggle Inventory visbility
    private bool dispInventory;						// Current Inventory visbility
    public GameObject InventoryPanel1, InventoryPanel2, BackgroundPanel;// List of inventory items + a background as panels

    // Start is called before the first frame update
    void Start()
    {
	// initialize the default state of the inventory to be not visbile
        dispInventory = false;
	// Associate the UI Button with the specific ToggleInventory function
        InventoryButton.onClick.AddListener(ToggleInventory);
    }

    // When the Inventory UI button is clicked, toggle the display visibility of the Inventory
    private void ToggleInventory()
    {
        Debug.Log("dispInventory = " + !dispInventory);
        dispInventory = !dispInventory;
    }

    // Update is called once per frame
    void Update()
    {
	// If the inventory should be visible, visualize it
        if (dispInventory)
        {
	    // For the specific case of the inventory ITEMS (which should be draggable), reference the current game state
	    // In our particular case, the player should have completed the first puzzle, indicated by GKBooleans.isButtonSolved before they can see the full inventory
            InventoryPanel1.SetActive(true && GKBooleans.isButtonSolved);
            InventoryPanel2.SetActive(true && GKBooleans.isButtonSolved);
	    // The Background Panel is always visualized
            BackgroundPanel.SetActive(true);
        }
	// Else, make sure that the inventory panel is visible
        else
        {
            InventoryPanel1.SetActive(false);
            InventoryPanel2.SetActive(false);
            BackgroundPanel.SetActive(false);
        }
        
    }
}
