using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TarodevController {
public class CheckpointManager : MonoBehaviour
{
    
    private LevelManager lm;

    void Start()
    {
        lm  = GameObject.FindGameObjectWithTag("GM").GetComponent<LevelManager>();
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player")) 
        {
            Debug.Log("Checkpoint!"); 
            lm.respawnPoint = gameObject.transform;            
        }
    }
}
}