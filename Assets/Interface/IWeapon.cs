using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


interface IWeapon
{
    int damage {
        get;
    }

    void addDamage(int damage);
    void removeDamage(int damage);
}

