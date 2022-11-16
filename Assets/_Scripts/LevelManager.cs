using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;    
    public Rigidbody2D playerRB;

    public CinemachineVirtualCameraBase cam;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Respawn() {
        StartCoroutine(DelayedRespawn());
    }

    IEnumerator DelayedRespawn()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;        
        playerRB.isKinematic = false;
    }
}
