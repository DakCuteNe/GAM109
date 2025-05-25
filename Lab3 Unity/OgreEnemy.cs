using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreEnemy : EnemyBase
{
    public int Armor { get; set; }

    public OgreEnemy(string name, int baseHealth, int armor) : base(name, baseHealth)
    {
        Armor = armor;
    }

    public override void Attack()
    {
        Debug.Log($"{Name} attacks with armor: {Armor}");
    }
}
