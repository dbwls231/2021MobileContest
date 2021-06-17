using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangaer : MonoBehaviour
{
    public GameObject enemy;
    private float enemySpawnDelay = 1;
    private float curEnemySpawnDelay = 1;
    private float enemyTimer = 0;
    private float spawnRadius = 11;
    

    private Vector3 spawnPos;

    private void Update()
    {
        enemyTimer += Time.deltaTime;

        if (enemySpawnDelay > 0.05)
            enemySpawnDelay -= Time.deltaTime * 0.01f;

        if (enemyTimer > curEnemySpawnDelay)
        {
            SpawnEnemy();
            curEnemySpawnDelay = Random.Range(enemySpawnDelay * 0.8f, enemySpawnDelay * 1.2f);
            enemyTimer = 0;
        }

    }

    void SpawnEnemy()
    {
        spawnPos = Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemy, spawnPos, transform.rotation);
    }

   

}
