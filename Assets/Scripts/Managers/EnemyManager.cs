using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public List<Enemy> enemies;

    public void stopEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.StopMovement();
        }
    }

}
