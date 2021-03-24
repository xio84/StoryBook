using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Text choice1Text;
    public Text choice2Text;
    public Animator animator;
    public Sentence currSentence;

    private Queue<Sentence> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<Sentence>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        Sentence sentence = sentences.Dequeue();
        currSentence = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence.text));

        if (sentence.hasChoices)
        {
            StartCoroutine(TypeChoice1(sentence.choices[0]));
            StartCoroutine(TypeChoice2(sentence.choices[1]));
        }
        else
        {
            choice1Text.text = "";
            choice2Text.text = "";
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    IEnumerator TypeChoice1(string choice1)
    {
        choice1Text.text = "";
        foreach (char letter in choice1.ToCharArray())
        {
            choice1Text.text += letter;
            yield return null;
        }
    }
    IEnumerator TypeChoice2(string choice2)
    {
        choice2Text.text = "";
        foreach (char letter in choice2.ToCharArray())
        {
            choice2Text.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End of convo.");
    }

}
