using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameSetup : MonoBehaviour
{
    private EnemyManagerCore enemyManagerCore;

    void Start()
    {
        enemyManagerCore = new EnemyManagerCore();

            enemyManagerCore.AddEnemy(new GoblinEnemy("Gobbo", 35, 0.25f));
            enemyManagerCore.AddEnemy(new GoblinEnemy("Sneaky", 55, 0.40f));
            enemyManagerCore.AddEnemy(new OgreEnemy("Gronk", 80, 15));
            enemyManagerCore.AddEnemy(new OgreEnemy("Brute", 45, 10));

        enemyManagerCore.ListAllEnemies();

        var fillteredEnemies = enemyManagerCore.GetEnemies()
            .Where(e => e.BaseHealth > 100)
            .Select(e => new
            {
                e.Name,
                EnemyType = e is GoblinEnemy ? "Goblin" : e is OgreEnemy ? "Orge" : "Unknown"
            });

        Debug.Log("Filtered Enemies:");
        foreach (var e in fillteredEnemies)
        {
            Debug.Log($"Name: {e.Name}, Type: {e.EnemyType}");
        }
    }
}
