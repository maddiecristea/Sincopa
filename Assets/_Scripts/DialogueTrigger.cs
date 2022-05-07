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
            if (Input.GetKey(KeyCode.E))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);             
            }
                
        }  
    }

    public void Update() 
    {      
        var isOpen = FindObjectOfType<DialogueManager>().CheckIfOpen();  
        if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            Debug.Log("Write only when open?");
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
}
}
