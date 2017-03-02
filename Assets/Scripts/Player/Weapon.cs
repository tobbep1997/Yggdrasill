using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour , IWeapon {

    [SerializeField]
    int damage = 10;
    int IWeapon.damage
    {
        get { return damage; }
    }

    void IWeapon.addDamage(int damage)
    {
        this.damage += damage;
    }
    void IWeapon.removeDamage(int damage)
    {
        this.damage -= damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Enemy")
        {
            IHealth health = other.GetComponent<IHealth>();
            health.damage(damage);
            health.callDestroy();
        }
    }
}
