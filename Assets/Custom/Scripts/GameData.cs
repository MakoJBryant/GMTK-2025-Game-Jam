using UnityEngine;
[System.Serializable]
public class GameData
{
    public float difficulty = 1;
    public float difficultyRamp = .1f;
    public int round = 1;
    public int roundLimit = 2;
    public readonly int fightSceneCount = 3;

    public void IncreaseDifficulty()
    {
        difficulty *= (difficulty + difficultyRamp);
    }
}
