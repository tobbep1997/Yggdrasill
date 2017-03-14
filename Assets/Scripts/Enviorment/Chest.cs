using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    [SerializeField]
    Button button;
    [SerializeField]
    PressurePlate pressurePlate;

    [SerializeField]
    Sprite sprite;


    SpriteRenderer render;

    bool pressed = false;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        render.enabled = pressurePlate.isPressed();
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pressurePlate.isPressed() && collision.transform.tag == "Player")
        {
            if (pressed)
                return;
            GetComponent<SpriteRenderer>().sprite = sprite;
            collision.transform.GetComponent<playerAttack>().scale += new Vector3(1, 1, 1);
            pressed = true;
        }
    }
}
