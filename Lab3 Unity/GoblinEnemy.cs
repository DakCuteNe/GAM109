using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : EnemyBase
{
    public float DodgeChance { get; set; }

    public GoblinEnemy(string name, int baseHealth, float dodgeChance) : base(name, baseHealth)
    {
        DodgeChance = dodgeChance;
    }

    public override void Attack()
    {
        Debug.Log($"{Name} attacks with a chance to dodge: {DodgeChance * 100}%");
    }
}
