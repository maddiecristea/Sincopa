using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    [SerializeField] private GameObject ToggledObject;
    public OneLineMessage onelinemessage;
    public float time; 

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        ToggledObject.gameObject.SetActive(false);
    }

    public IEnumerator ToggleMessage()
    {
        FindObjectOfType<MessageManager>().ShowMessage(onelinemessage);
        ToggledObject.gameObject.SetActive(true); 
        Debug.Log("open this");
        yield return new WaitForSeconds(time);
        Debug.Log("close this");
        ToggledObject.gameObject.SetActive(false); 
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.CompareTag("Player")) 
        {
            Debug.Log("Such key, much wow.");
            
            StartCoroutine(ToggleMessage());
            for (int i = 0; i < inventory.slots.Length; i++) 
            {

                if (inventory.isFull[i] == false) {
                    // ITEM CAN BE ADDED TO INVENTORY
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    gameObject.GetComponent<Renderer>().enabled = false;
                    //Destroy(gameObject);
                    break;
                }
            }    
        }
    }
    

}
