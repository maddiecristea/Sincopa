using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private GameObject ToggledObject;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        ToggledObject.gameObject.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        var hasItem = FindObjectOfType<Slot>().CheckIfHasItem();

        if (other.CompareTag("Player") && hasItem) 
        {
            Debug.Log("Oh, look! A shiny door!");
            FindObjectOfType<UseItemScript>().UseItem();
            Destroy(gameObject);
            
        }
        else {
            Debug.Log("I can't open this, I need a key.");
            ToggledObject.gameObject.SetActive(true);

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            ToggledObject.gameObject.SetActive(false);
        }
    }
}
