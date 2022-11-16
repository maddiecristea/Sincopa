using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProximityTrigger : MonoBehaviour
{

    [SerializeField] private GameObject ToggledObject;
    [SerializeField] private Image customImage;
    
    void Start() 
    {
        
        ToggledObject.gameObject.SetActive(false);
        Debug.Log("nooo.");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            if (ToggledObject.gameObject != null)
            {
                ToggledObject.gameObject.SetActive(true);
            }
             else
            {
               customImage.enabled = true;              
            }          
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            if (ToggledObject.gameObject != null)
            {
                ToggledObject.gameObject.SetActive(false);
            }
             else
            {
               customImage.enabled = false;              
            }  
        }
    }
}
