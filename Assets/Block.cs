using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField]
    KeyCode blockKey = KeyCode.B;

    PlayerBehavior pb;

    [SerializeField]
    GameObject shild;
    GameObject shildCopy;

    Rigidbody2D rb2D;
    Collider2D collider;

    bool blocking = false;

    public bool isBlocking
    {
        get { return blocking; }
    }

	// Use this for initialization
	void Start () {
        pb = GetComponent<PlayerBehavior>();
        rb2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(blockKey))
        {
            pb.enableControlls = false;
            if (shildCopy == null)
            shildCopy = Instantiate(shild, transform.position,Quaternion.identity,transform);
            rb2D.isKinematic = true;
            rb2D.velocity = Vector2.zero;
            collider.enabled = false;
            blocking = true;
        }
        else
        {
            blocking = false;
            pb.enableControlls = true;
            rb2D.isKinematic = false;
            collider.enabled = true;
            if (shildCopy != null)
                Destroy(shildCopy);
            shildCopy = null;
        }
	}
}
