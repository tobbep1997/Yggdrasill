using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    [SerializeField]
    Button button;
    [SerializeField]
    PressurePlate pressurePlate;

    MeshRenderer render;

    private void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        render.enabled = pressurePlate.isPressed();
    }
}
