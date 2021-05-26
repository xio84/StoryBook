using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue giftDialogue;
    public Dialogue dialogue_before;
    public Dialogue dialogue_after;
    public PressurePuzzle pressurePuzzle;
    public UnopenableDoor door;

    public void TriggerDialogue()
    {
        if (pressurePuzzle.isOpen)
        {
            door.Open();
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue_after);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue_before);
        }
        
    }

    public void TriggerGift()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(giftDialogue);
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
