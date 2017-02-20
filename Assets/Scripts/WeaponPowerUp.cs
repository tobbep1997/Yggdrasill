using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour {

    [SerializeField]
    GameObject newWeapond;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            print("Hello");
            playerAttack attack = collider.transform.GetComponent<playerAttack>();
            attack.weapond = newWeapond;
            Destroy(gameObject);
        }
    }
}
