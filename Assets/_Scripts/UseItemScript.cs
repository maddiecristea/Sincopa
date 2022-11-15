using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemScript : MonoBehaviour
{

    public void UseItem() 
    {
        GameObject.Destroy(gameObject);
    }
    
}
