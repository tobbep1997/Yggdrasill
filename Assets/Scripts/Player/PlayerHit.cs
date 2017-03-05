using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

    [SerializeField]
    Collider2D col;
    [SerializeField]
    Rigidbody2D rb2D;

    [SerializeField]
    PlayerHit other;

    public bool dead = false;




    float timer;
    float time = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Weapond" && !dead)
        {
            GetComponent<PlayerBehavior>().enableControlls = false;
            dead = true;
            Hit();

        }
    }

    private void Update()
    {
        if (dead && !other.dead)
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                
                other.dead = true;
                
                other.Hit();
            }
            
        }
    }

    public void Hit()
    {
        if (!dead)
            return;
        GetComponent<PlayerBehavior>().enableControlls = false;
        rb2D.AddForce(Vector2.up * 256);
        col.enabled = false;
    } 
}
