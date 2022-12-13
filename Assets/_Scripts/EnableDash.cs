using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TarodevController {
    /// <summary>
    /// Hey!
    /// Tarodev here. I built this controller as there was a severe lack of quality & free 2D controllers out there.
    /// Right now it only contains movement and jumping, but it should be pretty easy to expand... I may even do it myself
    /// if there's enough interest. You can play and compete for best times here: https://tarodev.itch.io/
    /// If you hve any questions or would like to brag about your score, come to discord: https://discord.gg/GqeHHnhHpz
    /// </summary>
    public class EnableDash : MonoBehaviour
    {
        public float time; 
        public PlayerController PC;

        // Start is called before the first frame update
        void Start()
        {
            PC = gameObject.GetComponent<PlayerController>();
        }

        void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Power")) 
            {
                PC._dashToConsume = false; 
                GameObject.FindGameObjectWithTag("Power").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                StartCoroutine(DisableDash());                     
            }
        }
        
        
        IEnumerator DisableDash()
        {
            yield return new WaitForSeconds(time);
            GameObject.FindGameObjectWithTag("Power").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}