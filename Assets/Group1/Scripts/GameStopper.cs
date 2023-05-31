using System.Collections.Generic;
using UnityEngine;

public class GameStopper : MonoBehaviour
{
    [SerializeField] private EndGameWindow _endGameWindow;
    [SerializeField] private List<Enemy> _enemies;

    private void OnEnable()
    {
        foreach(Enemy enemy in _enemies)
        {
            enemy.Dead += OnEnemyDead;
        }
    }

    private void OnEnemyDead(Enemy enemy)
    {
        _enemies.Remove(enemy);
        enemy.Dead -= OnEnemyDead;

        if (_enemies.Count == 0)
            EndGame();
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        _endGameWindow.Activate();
    }
}
