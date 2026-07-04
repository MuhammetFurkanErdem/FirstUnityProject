using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [Header ("Managers")]
    public EnemyManager enemyManager;
    public LevelManager levelManager;

    public void Start()
    {
        levelManager.RestartLevel();
    }

    public void LevelCompleted()
    {
        enemyManager.stopEnemies();

    }
}
