using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

    [SerializeField]
    Collider2D col;
    [SerializeField]
    Rigidbody2D rb2D;

    bool dead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Weapond" && !dead)
        {
            rb2D.AddForce(Vector2.up * 256);
            col.enabled = false;
        }
    }
}
