using UnityEngine;

public class Game_Data
{
    public float difficulty = 1;
    public float difficultyRamp = .1f;
    public float spawnRate = 1;
    public int enemiesToSpawn = 1;
    public int round = 1;

    public void IncreaseDifficulty()
    {
        difficulty *= (difficulty + difficultyRamp);
        spawnRate /= difficulty;
        enemiesToSpawn = Mathf.RoundToInt(enemiesToSpawn * difficulty);
        Debug.Log("difficulty = " + difficulty + ", spawnRate = " + spawnRate + ", enemiesToSpawn = " + enemiesToSpawn);
    }
}
