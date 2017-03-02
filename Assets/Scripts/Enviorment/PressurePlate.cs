using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    bool _isPressed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            _isPressed = true;
        }
    }

    public bool isPressed()
    {
        return _isPressed;
    }
}
