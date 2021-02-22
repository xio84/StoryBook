using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isActive;
    [SerializeField] private GameObject InteractCanvas;

    public void DoSomething()
    {
        Debug.Log(this.name);
    }

    public void setActive(bool activ)
    {
        Debug.Log(activ);
        isActive = activ;
        if (isActive)
        {
            Debug.Log("Active");
            Instantiate(InteractCanvas, this.transform);
        }
        else
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
        }
    }
}
