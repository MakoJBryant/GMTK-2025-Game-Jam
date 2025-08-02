using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform playerEntrance;
    [SerializeField] private List<Transform> entrances = new();
    [SerializeField] private int enemiesToSpawn = 10;
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private bool spawnEnemiesInRoom = true;

    [SerializeField] private Transform enemyContainer;
    public Transform EnemyContainer => enemyContainer;


    private void Start()
    {
        InitEnemyPool();
        StartCoroutine(SpawnRoutine());
        GameManager.instance.player.transform.position = playerEntrance.position;
    }

    private void InitEnemyPool()
    {
        int currentRound = GameManager.instance.data.round;
        for (int i = 0; i < enemiesToSpawn + currentRound; i++)
        {
            GameObject newEnemy = Instantiate(enemy, enemyContainer);
            enemy.SetActive(false);
            Debug.Log("Enemy added to pool");
        }
    }

    private IEnumerator SpawnRoutine()
    {
        if (spawnEnemiesInRoom)
        {
            foreach (Transform newEnemy in enemyContainer)
            {
                yield return new WaitForSeconds(timeBetweenSpawn);

                newEnemy.gameObject.SetActive(true);

                int entranceIndex = Random.Range(0, entrances.Count);
                Vector2 spawnPos = entrances[entranceIndex].position;
                newEnemy.position = spawnPos;
            }
        }
    }
}
