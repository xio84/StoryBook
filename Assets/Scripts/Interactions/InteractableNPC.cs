using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour, IInteractables
{

    public DialogueTrigger dialogueTrigger;

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
        dialogueTrigger.TriggerDialogue();
        Debug.Log("interacted");
        return true;
    }
}
