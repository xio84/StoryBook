using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
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
