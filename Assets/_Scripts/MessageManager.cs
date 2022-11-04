using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public Text needobjText;
    public Text messageText;

    public void ShowMessage(OneLineMessage onelinemessage) 
    {
        needobjText.text = onelinemessage.message;
        messageText.text = onelinemessage.message;
    }
}
