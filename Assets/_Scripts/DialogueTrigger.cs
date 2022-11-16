using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TarodevController {
    public class DialogueTrigger : MonoBehaviour
    {
        public Dialogue dialogue;
        private PlayerInputActions _input;

        public void Start() {
            var isOpen = FindObjectOfType<DialogueManager>().CheckIfOpen(); 
            isOpen = false;
            _input = new PlayerInputActions();
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
                if (_input.Player.Interact.ReadValue<bool>() && !isOpen)
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
            if (_input.Player.Interact.ReadValue<bool>() && isOpen)
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
}
