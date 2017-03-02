using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class projectile : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rb2D;

    private void Start()
    {
        //rb2D.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float rotation = (Mathf.Atan2(rb2D.velocity.y, rb2D.velocity.x))* Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
