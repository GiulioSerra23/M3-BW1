using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Enemy[] _enemiesArr;
    [SerializeField] private Transform[] _spawnpos;
    [SerializeField] private float _spawnTimer;
    [SerializeField] private int _maxEnemies;

    private float timer;

    public void AddEnemy (Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }

    public void SpawnEnemy()
    {
        Transform spawnPoint = _spawnpos[Random.Range(0, _spawnpos.Length)];
        Enemy enemySpawned = _enemiesArr[Random.Range(0, _enemiesArr.Length)];

        Instantiate(enemySpawned, spawnPoint);
    }

    private void Update()
    {
        if(_enemies.Count < _maxEnemies)
        {
            timer += Time.deltaTime;

            if (timer > _spawnTimer)
            {
                SpawnEnemy();
                timer = 0;
            }
        }        
    }
}
