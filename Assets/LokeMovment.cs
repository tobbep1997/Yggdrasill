using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokeMovment : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
	}
}
