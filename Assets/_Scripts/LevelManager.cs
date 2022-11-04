using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public CinemachineVirtualCameraBase cam;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
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
    }
}
