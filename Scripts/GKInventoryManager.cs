using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GKInventoryManager : MonoBehaviour
{
    public Button InventoryButton;
    private bool dispInventory;
    public GameObject InventoryPanel1, InventoryPanel2, BackgroundPanel;
    // Start is called before the first frame update
    void Start()
    {
        dispInventory = false;
        InventoryButton.onClick.AddListener(ToggleInventory);

    }

    private void ToggleInventory()
    {
        Debug.Log("dispInventory = " + !dispInventory);
        dispInventory = !dispInventory;
    }


    // Update is called once per frame
    void Update()
    {
        if (dispInventory)
        {
            InventoryPanel1.SetActive(true && GKBooleans.isButtonSolved);
            InventoryPanel2.SetActive(true && GKBooleans.isButtonSolved);
            BackgroundPanel.SetActive(true);
        }
        else
        {
            InventoryPanel1.SetActive(false);
            InventoryPanel2.SetActive(false);
            BackgroundPanel.SetActive(false);
        }
        
    }
}
