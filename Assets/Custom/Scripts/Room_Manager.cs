using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Room_Manager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new();
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform enemyContainer;
    [SerializeField] List<Transform> entrances = new();
    
    private void Start()
    {
        InitEnemyPool();
        StartCoroutine(SpawnRoutine());
    }

    void InitEnemyPool()
    {
        int poolSize = Game_Manager.instance.data.enemiesToSpawn;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newEnemy = Instantiate(enemy, enemyContainer);
            enemies.Add(newEnemy);
            newEnemy.SetActive(false);
        }
    }

    IEnumerator SpawnRoutine()
    {
        foreach(GameObject enemy in enemies)
        {
            yield return new WaitForSeconds(1);

            int entranceIndex = Random.Range(0, entrances.Count);
            Vector2 spawnPos = entrances[entranceIndex].position;
            enemy.SetActive(true);
            enemy.transform.SetParent(null);
            enemy.transform.position = spawnPos;
        }
    }
}
