using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;
    public Enemy enemyPrefab;
    public List<Enemy> enemies;

    public Vector2 enemyCount;

    public void RestartEnemyManager()
    {
        DeleteEnemies();
        GenerateEnemies();
    }

    public void GenerateEnemies()
    {
        var randomEnemyCount = UnityEngine.Random.Range((int)enemyCount.x, (int)enemyCount.y);
        for (int i = 0; i < randomEnemyCount; i++)
        {
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(UnityEngine.Random.Range(-3.5f, 3.5f), 0, -2 + i * 2f);
            enemies.Add(newEnemy);
            newEnemy.StartEnemy(player);

        }
    }


    public void DeleteEnemies()
    {
        foreach (var enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        enemies.Clear();
    }

    public void stopEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.StopMovement();
        }
    }

}
