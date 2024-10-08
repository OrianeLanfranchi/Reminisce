using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using System;

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
    private bool waitForNext;

    private void Start()
    {
        index = 0;
        ToggleWindow(false);
        started = false;
        waitForNext = false;
    }
    public virtual void onInteract()
    {
        Debug.Log("oI - C'est p�t�");
        StartDialogue();
    }

    public void CloseWindow()
    {
        window.SetActive(false);
        index = 0;
        charIndex = 0;
    }

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
        Debug.Log("SD - C'est p�t�");
        //show window
        ToggleWindow(true);
        //hide indicator
        //ToggleWindow(false);
        GetDialogue(index);
    }

    private void GetDialogue(int i)
    {

        Debug.Log("GD - 1 - C'est p�t�");
        started = true;
        Debug.Log("GD - 2 - C'est p�t�");
        //start with index at 0
        //set index at 0
        index = i;
        //Reset character index
        charIndex = 0;
        //clear dialogue component text
        if(index < dialogues.Count)
        {
            dialogueText.text = string.Empty;
            //Start writing
            StartCoroutine(Writing());
        }
        else
        {
            ToggleWindow(false);
            index = 0;
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
        Debug.Log("W - C'est p�t�");
        string currentDialogue = dialogues[index]; //�a p�te ici 
        Debug.Log("C'est pas p�t� ?");
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
            index++;
        }

    }

    private void Update()
    {
        if (!started) return;

        if (waitForNext && Input.GetKeyDown(KeyCode.A))
        {
            waitForNext = false;
            index++;
            if (index < dialogues.Count)
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
