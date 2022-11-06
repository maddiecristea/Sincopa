using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void Start() {
        var isOpen = FindObjectOfType<DialogueManager>().CheckIfOpen(); 
        isOpen = false;
    }


    public void TriggerDialogue () 
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        var isOpen = FindObjectOfType<DialogueManager>().CheckIfOpen(); 

        if(other.CompareTag("Player"))
        {
            if (Input.GetButton("Interact") && !isOpen)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);    
                isOpen = true;     
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
            StartCoroutine(NextSentence());          
        }
    }

    IEnumerator NextSentence()
    {
        yield return new WaitForSeconds(0.2f);        
        FindObjectOfType<DialogueManager>().DisplayNextSentence();  
    }
}
