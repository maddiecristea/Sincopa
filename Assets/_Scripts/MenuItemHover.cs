using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemHover : MonoBehaviour
{

    void OnMouseOver()
    {
        Debug.Log("Mouse Over");
    }


    void OnMouseExit()
    {
        Debug.Log("Mouse Off");
    }
}
