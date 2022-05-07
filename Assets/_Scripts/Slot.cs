using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0) 
        {
            inventory.isFull[i] = false;
        }                                     
    }

    public bool CheckIfHasItem() 
    {
        if (transform.childCount <= 0) 
        {
            return (false);
        }  
        else 
        {
            return (true);
        }
    }

}
