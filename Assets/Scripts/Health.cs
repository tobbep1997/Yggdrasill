using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Health : MonoBehaviour , IHealth
{
    [SerializeField]
    int health = 100;

    int IHealth.health
    {
        get { return health; }
    }

    void IHealth.damage(int damage)
    {
        health -= damage;
    }
    void IHealth.heal(int health)
    {
        this.health += health;
    }

    bool IHealth.dead()
    {
        return health <= 0;
    }

    void IHealth.callDestroy()
    {
        Destroy(gameObject);
    }

}

