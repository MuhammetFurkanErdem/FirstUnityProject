using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public Player player;

    [Header ("Managers")]
    public EnemyManager enemyManager;
    public LevelManager levelManager;

    private void Start()
    {
        RestartLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        levelManager.RestartLevelManager();
        enemyManager.RestartEnemyManager();
        player.RestartPlayer();
    }

    public void LevelCompleted()
    {
        enemyManager.stopEnemies();

        Debug.Log("LEVEL COMPLETED");

        // Buraya ileride:
        // - Win Panel
        // - Sonraki Level
        // - Coin Ödülü
        // eklenebilir.
    }

    public void GameOver()
    {
        enemyManager.stopEnemies();

        Debug.Log("GAME OVER");

        // Buraya ileride:
        // - Game Over Panel
        // - Retry Butonu
        // - Reklam
        // eklenebilir.
    }
}
