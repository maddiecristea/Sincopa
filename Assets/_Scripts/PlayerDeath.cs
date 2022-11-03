using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TarodevController {
    /// <summary>
    /// This is a pretty filthy script. I was just arbitrarily adding to it as I went.
    /// You won't find any programming prowess here.
    /// This is a supplementary script to help with effects and animation. Basically a juice factory.
    /// </summary>
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
                FindObjectOfType<PlayerAnimator>().OnDeath();
                StartCoroutine(DelayedDeath());          
            }
        }

        IEnumerator DelayedDeath()
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
            LevelManager.instance.Respawn();  
        }

    }
}
