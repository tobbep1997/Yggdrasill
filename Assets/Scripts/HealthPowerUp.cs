using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour , IObject {

    [SerializeField]
    int _value = 25;
    const bool _pickUp = true;
    int IObject.value
    {
        get { return _value; }
    }
    bool IObject.pickUp
    {
        get { return _pickUp; }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBehavior>() != null)
        {
            Destroy(transform);
        }
    }

    
}
