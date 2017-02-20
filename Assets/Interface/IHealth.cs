using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

interface IHealth
{
    int health
    {
        get;
    }

    void damage(int damage);
    void heal(int health);

    bool dead();

    void callDestroy();
}

