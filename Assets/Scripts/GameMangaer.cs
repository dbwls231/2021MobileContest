using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangaer : MonoBehaviour
{
    public GameObject enemy;
    public GameObject []items;
    private float enemySpawnDelay = 1;
    private float curEnemySpawnDelay = 1;
    private float enemyTimer = 0;
    private float itemCreateDelay = 4;
    private float itemTimer = 0;
    private float spawnRadius = 9;
    

    private Vector3 spawnPos;

    private void Update()
    {
        enemyTimer += Time.deltaTime;
        itemTimer += Time.deltaTime;

        if (enemySpawnDelay > 0.05)
            enemySpawnDelay -= Time.deltaTime * 0.01f;

        if (enemyTimer > curEnemySpawnDelay)
        {
            SpawnEnemy();
            curEnemySpawnDelay = Random.Range(enemySpawnDelay * 0.8f, enemySpawnDelay * 1.2f);
            enemyTimer = 0;
        }

        if (itemTimer > itemCreateDelay)
        {
            CreateItem();
            itemTimer = 0;
        }
    }

    void SpawnEnemy()
    {
        spawnPos = Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemy, spawnPos, transform.rotation);

    }

    void CreateItem()
    {
        Debug.Log("ItemCreate");
        spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
        
        Instantiate(items[0], spawnPos, transform.rotation);
        
    }

}
