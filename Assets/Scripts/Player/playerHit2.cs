using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit2 : MonoBehaviour {

    [SerializeField]
    GameObject hitObject;
    GameObject gObject;

    [SerializeField]
    float speed = 150;

    Block block;
    private void Start()
    {
        block = GetComponent<Block>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Weapond" && !block.isBlocking)
        {
            
            gObject = Instantiate(hitObject, transform.position, Quaternion.identity);
            Vector2 rand = new Vector2(Random.Range(-1f, 1f), 2);
            gObject.GetComponent<Rigidbody2D>().AddForce(rand * speed);
            gObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-speed,speed));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Weapond" && !block.isBlocking)
        {

            gObject = Instantiate(hitObject, transform.position, Quaternion.identity);
            Vector2 rand = new Vector2(Random.Range(-1f, 1f), 2);
            gObject.GetComponent<Rigidbody2D>().AddForce(rand * speed);
            gObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-speed, speed));
        }
    }
}
