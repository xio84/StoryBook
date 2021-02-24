using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] LayerMask interactLayer;
    private List<GameObject> interactiveObjects;
    private GameObject activeInteractable;
    

    private void Start()
    {
        interactiveObjects = (interactiveObjects == null) ? new List<GameObject>() : interactiveObjects;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && interactiveObjects.Count>1)
        {
            if (activeInteractable != null)
            {
                activeInteractable.GetComponent<Interactable>().setInactive();
                activeInteractable = interactiveObjects[(interactiveObjects.IndexOf(activeInteractable) + 1) % interactiveObjects.Count];
                activeInteractable.GetComponent<Interactable>().setActive();
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            interactiveObjects.Add(other.gameObject);
            if (activeInteractable == null )
            {
                activeInteractable = interactiveObjects[0];
                activeInteractable.GetComponent<Interactable>().setActive();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            interactiveObjects.Remove(other.gameObject);
            if (other.gameObject == activeInteractable)
            {
                other.gameObject.GetComponent<Interactable>().setInactive();
                if (interactiveObjects.Count>0)
                {
                    activeInteractable = interactiveObjects[0];
                    activeInteractable.GetComponent<Interactable>().setActive();
                }else activeInteractable = null;
            }
        }
    }
}
