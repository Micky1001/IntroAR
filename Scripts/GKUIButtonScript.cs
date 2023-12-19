using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GKUIButtonScript : MonoBehaviour
{
    public Button filterButton;
    public GameObject redObject, greenObject, blueObject;
    private bool cheked = false;
    private int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        filterButton.onClick.AddListener(ChangeFilter);
        redObject.SetActive(false);
        greenObject.SetActive(false);
        blueObject.SetActive(false);
        
    }


    void ChangeFilter()
    {
        Debug.Log(state);
        state += 1;
        //if (state >= 4) { state = 0; filterButton.colors = ColorBlock.defaultColorBlock; }
        //else if (state == 1) { block.normalColor = Color.red; filterButton.colors = block; }
        //else if (state == 2) { block.normalColor = Color.green; filterButton.colors = block; }
        //else { block.normalColor = Color.blue; filterButton.colors = block; }
        if (state >= 4) {
            state = 0;
            filterButton.GetComponent<Image>().color = Color.white;
            redObject.SetActive(false);
            greenObject.SetActive(false);
            blueObject.SetActive(false);
        }
        else if (state == 1) {
            filterButton.GetComponent<Image>().color = Color.red;
            redObject.SetActive(true);
        }
        else if (state == 2) {
            filterButton.GetComponent<Image>().color = Color.green;
            redObject.SetActive(false);
            greenObject.SetActive(true);
        }
        else {
            filterButton.GetComponent<Image>().color = Color.blue;
            greenObject.SetActive(false);
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
