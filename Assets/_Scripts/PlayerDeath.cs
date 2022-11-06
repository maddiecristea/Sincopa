using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TarodevController {
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        public Animator _anim;
        public AudioClip _deathClip;
        public float time;
        public Rigidbody2D playerRB;

        private void OnCollisionEnter2D(Collision2D other) { 
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "DeathZone") 
            {
                Debug.Log("You just died. Congrats!");   
                _anim.SetTrigger("Dead"); 
                _source.PlayOneShot(_deathClip);
                FindObjectOfType<PlayerAnimator>().OnDeath();
                playerRB.isKinematic = true;
                StartCoroutine(DelayedDeath());          
            }
        }

        IEnumerator DelayedDeath()
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
            LevelManager.instance.Respawn();  
        }

    }
}
