using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPush : MonoBehaviour
{
    public Text Display;

    // Start is called before the first frame update
    void Start()
    {
        Display.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void One_Pressed()
    {
        if (Display.text.Length < 4)
        {
            Display.text += "1";
        }
    }

    public void Two_Pressed()
    {
        if (Display.text.Length < 4)
        {
            Display.text += "2";
        }
    }

    public void Three_Pressed()
    {
        if (Display.text.Length < 4)
        {
            Display.text += "3";
        }
    }

    public void Four_Pressed()
    {
        if (Display.text.Length < 4)
        {
            Display.text += "4";
        }
    }
    public void Five_Pressed()
    {
        if (Display.text.Length < 4)
        {
            Display.text += "5";
        }
    }

    public void Six_Pressed()
    {
        if (Display.text.Length < 4)
        {
            Display.text += "6";
        }
    }

    public void Seven_Pressed()
    {
        if (Display.text.Length < 4)
        {
            Display.text += "7";
        }
    }

    public void Eight_Pressed()
    {
        if (Display.text.Length < 4)
        {
            Display.text += "8";
        }
    }

    public void Nine_Pressed()
    {
        if (Display.text.Length < 4)
        {
            Display.text += "9";
        }
    }

    public void Zero_Pressed()
    {
        if (Display.text.Length < 4)
        {
            Display.text += "0";
        }
    }

    public void Delete_Pressed()
    {
        Display.text = "";
    }

    public void Enter_Pressed()
    {
        if (Display.text == "1234")
        {
            Display.text = "OK :)";
        }
        else if (Display.text == "OK :)")
        {
            // do nothing
        }
        else
        {
            Display.text = "NO :(";
        }
    }
}
