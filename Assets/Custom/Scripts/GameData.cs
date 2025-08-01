using UnityEngine;

public class GameData
{
    public float difficulty = 1;
    public float difficultyRamp = .1f;
    public int round = 1;

    public void IncreaseDifficulty()
    {
        difficulty *= (difficulty + difficultyRamp);
    }
}
