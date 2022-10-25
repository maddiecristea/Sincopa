using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    public Animator _anim;
    public AudioClip _deathClip;

    private void OnCollisionEnter2D(Collision2D other) { 
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "DeathZone") 
        {
            Debug.Log("You just died. Congrats!");   
            _anim.SetTrigger("Dead"); 
            _source.PlayOneShot(_deathClip);
            StartCoroutine(DelayedDeath());          
        }
    }

    IEnumerator DelayedDeath()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        LevelManager.instance.Respawn();  
    }

}
