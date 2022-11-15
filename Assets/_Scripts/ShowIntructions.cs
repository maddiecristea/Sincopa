using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIntructions : MonoBehaviour
{
    [SerializeField] private GameObject ToggledObject;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
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
