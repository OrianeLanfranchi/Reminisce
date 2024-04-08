using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;

public class DialogueBox : MonoBehaviour
{
    public GameObject window;
    //public GameObject indicator;
    public List<string> dialogues;
    //Txt component
    public TMP_Text dialogueText;
    //writing speed
    public float writingSpeed;
    private int index;
    private int charIndex;
    private bool started;
    //wait for next bool
    private bool waitForNext = false;


    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    //private void ToggleIndicator(bool show)
    //{
    //    window.SetActive(show);
    //}

    //Start Dialogue 
    public void StartDialogue()
    {
        //show window
        ToggleWindow(true);
        //hide indicator
        //ToggleWindow(false);

        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        if (!started)
        {
            started = true;
            //start with index at 0
            //set index at 0
            index = i;
            //Reset character index
            charIndex = 0;
            //clear dialogue component text
            dialogueText.text = string.Empty;
            //Start writing
            StartCoroutine(Writing());
        }
    }

    //End dialogue
    public void EndDialogue()
    {
        //hide window
        ToggleWindow(false);
    }

    //Writing logic
    IEnumerator Writing()
    {
        string currentDialogue = dialogues[index];
        //write characters
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index
        charIndex++;

        //check end sentence
        if (charIndex < currentDialogue.Length)
        {
            //wait x seconds
            yield return new WaitForSeconds(writingSpeed);

            //restart same process
            StartCoroutine(Writing());
        }
        else
        {
            waitForNext = true;
        }
    }

    private void Update()
    {
        if (!started) return;

        if (waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;
            if(index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                EndDialogue();
            }
        }
    }

}
