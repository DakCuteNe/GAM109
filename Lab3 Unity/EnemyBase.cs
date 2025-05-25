using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase
{
    public string Name { get; set; }

    public int BaseHealth { get; set; }

    public EnemyBase(string name, int baseHealth)
    {
        Name = name;
        BaseHealth = baseHealth;
    }

    public abstract void Attack();
}
