using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    public Sprite high1;
    public Sprite high2;
    public Sprite high3;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = high1;
    }

    public void High1()
    {
        img.sprite = high1;
    }
    public void High2()
    {
        img.sprite = high2;
    }
    public void High3()
    {
        img.sprite = high3;
    }
}
