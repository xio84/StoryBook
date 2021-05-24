using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractables
{
    public string keyID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IInteractables.Interact(string key)
    {
        Debug.Log(key + " Interact");
        if (key == keyID)
        {
            Vector3 direction = new Vector3(0, 10, 0);
            transform.position = transform.position + direction;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int Think()
    {
        return 1;
    }
}
