using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;


    public void TriggerDialogue () 
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnTriggerStay2D(Collider2D other)
    {

        if(other.CompareTag("Player"))
        {
            if (Input.GetButton("Interact"))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);             
            }
                
        }  
    }

    public void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) 
        {
            FindObjectOfType<DialogueManager>().EndDialogue();   
        }
    }

    public void Update() 
    {      
        var isOpen = FindObjectOfType<DialogueManager>().CheckIfOpen();  
        if (Input.GetButtonDown("Interact") && isOpen)
        {
            Debug.Log("Write only when open?");
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
}
}
