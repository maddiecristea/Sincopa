using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TarodevController {
    public class DialogueTrigger : MonoBehaviour
    {
        public Dialogue dialogue;
        private PlayerInput playerInput;
        private PlayerInputActions _input;

        public void Start() {
            var isOpen = FindObjectOfType<DialogueManager>().CheckIfOpen(); 
            isOpen = false;
        }

        private void Awake() {

            playerInput = GetComponent<PlayerInput>();
            
            _input = new PlayerInputActions();
            _input.Player.Enable();
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
                if (_input.Player.Interact.ReadValue<float>() == 1 && !isOpen)
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
            if (_input.Player.Interact.triggered && _input.Player.Interact.ReadValue<float>() == 1 && isOpen)
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
