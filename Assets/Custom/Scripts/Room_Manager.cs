using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Room_Manager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public Transform enemyContainer;
    [SerializeField] List<Transform> entrances = new();
    [SerializeField] private int enemiesToSpawn = 10;
    [SerializeField] private float timeBetweenSpawn;

    private void Start()
    {
        InitEnemyPool();
        StartCoroutine(SpawnRoutine());
    }

    void InitEnemyPool()
    {
        int currentRound = Game_Manager.instance.data.round;
        for (int i = 0; i < enemiesToSpawn + currentRound; i++)
        {
            GameObject newEnemy = Instantiate(enemy, enemyContainer);
            enemy.SetActive(false);
            Debug.Log("Enemy added to pool");
        }
    }

    IEnumerator SpawnRoutine()
    {
/*        foreach (Transform newEnemy in enemyContainer)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);

            newEnemy.gameObject.SetActive(true);

            int entranceIndex = Random.Range(0, entrances.Count);
            Vector2 spawnPos = entrances[entranceIndex].position;
            newEnemy.position = spawnPos;
        }*/

        for (int i = 0; i < enemyContainer.childCount; i++)
        {
            Transform newEnemy = enemyContainer.GetChild(i).transform;

            newEnemy.gameObject.SetActive(true);

            int entranceIndex = Random.Range(0, entrances.Count);
            Vector2 spawnPos = entrances[entranceIndex].position;
            newEnemy.position = spawnPos;

            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
