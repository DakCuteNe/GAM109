using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyManagerCore
{
    private List<EnemyBase> enemies = new List<EnemyBase>();

    public void AddEnemy<T>(T enemy) where T : EnemyBase
    {
        enemies.Add(enemy);
    }

    public void ListAllEnemies()
    {
        foreach (var enemy in enemies)
        {
            Debug.Log($"Enemy Name: {enemy.Name}, Health: {enemy.BaseHealth}");
        }
    }

    public List<EnemyBase> GetEnemies()
    {
        return enemies;
    }
}
