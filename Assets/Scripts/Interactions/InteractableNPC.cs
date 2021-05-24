using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour, IObjects
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

    void IObjects.Interact(GameObject player)
    {
        dialogueTrigger.TriggerDialogue();
        Debug.Log("interacted");
    }

    public int Think()
    {
        return 0;
    }
}
