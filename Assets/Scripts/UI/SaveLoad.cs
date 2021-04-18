using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    /*public Sprite unhigh;*/
    public Sprite high1;
    public Sprite high2;
    public Sprite high3;
    public Text confirmation;
    public string action;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    /*public void Unhigh()
    {
        img.sprite = unhigh;
    }*/

    public void High1()
    {
        img.sprite = high1;
        if (action == "save")
        {
            confirmation.text = "Save to 'Slot 1'?";
        }
        else if (action == "overwrite")
        {
            confirmation.text = "Overwrite to 'Slot 1'?";
        }
        else if (action == "load")
        {
            confirmation.text = "Load from 'Slot 1'?";
        }
        else
        {
            confirmation.text = "'Slot 1'?";
        }
    }
    public void High2()
    {
        img.sprite = high2;
        if (action == "save")
        {
            confirmation.text = "Save to 'Slot 2'?";
        }
        else if (action == "overwrite")
        {
            confirmation.text = "Overwrite to 'Slot 2'?";
        }
        else if (action == "load")
        {
            confirmation.text = "Load from 'Slot 2'?";
        }
        else
        {
            confirmation.text = "'Slot 2'?";
        }
    }
    public void High3()
    {
        img.sprite = high3;
        if (action == "save")
        {
            confirmation.text = "Save to 'Slot 3'?";
        }
        else if (action == "overwrite")
        {
            confirmation.text = "Overwrite to 'Slot 3'?";
        }
        else if (action == "load")
        {
            confirmation.text = "Load from 'Slot 3'?";
        }
        else
        {
            confirmation.text = "'Slot 3'?";
        }
    }
}
