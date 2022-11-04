using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowIntructions : MonoBehaviour
{
    [SerializeField] private GameObject ToggledObject;
    public OneLineMessage onelinemessage;

    private void Start()
    {
        ToggledObject.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            FindObjectOfType<MessageManager>().ShowMessage(onelinemessage);
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
