using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue_before;
    public Dialogue dialogue_after;
    public PressurePuzzle pressurePuzzle;

    public void TriggerDialogue()
    {
        if (pressurePuzzle.isOpen)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue_after);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue_before);
        }
        
    }
    public void Choice1()
    {
        //FindObjectOfType<DialogueManager>().currSentence.itemId;
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    public void Choice2()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
