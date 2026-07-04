using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;
    public Enemy enemyPrefab;
    public List<Enemy> enemies;

    public int enemyCount;

    public void RestartEnemyManager()
    {
        DeleteEnemies();
        GenerateEnemies();
    }

    public void GenerateEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var enemyXPosition = UnityEngine.Random.Range(-3.2f, 3.2f);
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(enemyXPosition, 0, -2 + i * 1.5f);
            enemies.Add(newEnemy);
            newEnemy.StartEnemy(player);

        }
    }


    public void DeleteEnemies()
    {
        
    }

    public void stopEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.StopMovement();
        }
    }

}
