using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    //private Rigidbody getRigidBody;
    [SerializeField] LayerMask interactLayer;
    private List<GameObject> interactiveObjects;
    //private float[] eachDistance;
    private GameObject activeInteractable;

    private void Start()
    {
        interactiveObjects = (interactiveObjects == null) ? new List<GameObject>() : interactiveObjects;
    }

    void Update()
    {
        if (interactiveObjects.Count>0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                activeInteractable.GetComponent<Interactable>().DoSomething();
            }

            if (Input.GetKeyDown(KeyCode.R) && interactiveObjects.Count>1)
            {
                if (activeInteractable != null)
                {
                    activeInteractable.GetComponent<Interactable>().setActive(false);
                    activeInteractable = interactiveObjects[(interactiveObjects.IndexOf(activeInteractable) + 1) % interactiveObjects.Count];
                    activeInteractable.GetComponent<Interactable>().setActive(true);
                }
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
                activeInteractable.GetComponent<Interactable>().setActive(true);
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
                other.gameObject.GetComponent<Interactable>().setActive(false);
                if (interactiveObjects.Count>0)
                {
                    activeInteractable = interactiveObjects[0];
                    activeInteractable.GetComponent<Interactable>().setActive(true);
                }else activeInteractable = null;
            }
        }
    }
}
