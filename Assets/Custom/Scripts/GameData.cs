using UnityEngine;
[System.Serializable]
public class GameData
{
    public float difficulty = 1;
    public float difficultyRamp = .1f;
    public int round = 0;
    public int roundLimit = 3;
    public readonly int fightSceneCount = 3;

    public void IncreaseDifficulty()
    {
        difficulty *= (difficulty + difficultyRamp);
        SaveData();
    }

    public void IncrementRound()
    {
        round++;
        SaveData();
    }

    public void ResetRounds()
    {
        round = 0;
        SaveData();
    }

    public int GetRound()
    {
        return PlayerPrefs.GetInt("Round");
    }

    public float GetDifficulty()
    {
        return PlayerPrefs.GetFloat("Difficulty");
    }

    public void ClearData()
    {
        PlayerPrefs.SetFloat("Difficulty", 1);
        PlayerPrefs.SetInt("Round", 0);
    }

    public void LoadData()
    {
        difficulty = GetDifficulty();
        round = GetRound();
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("Difficulty", difficulty);
        PlayerPrefs.SetInt("Round", round);
    }
}
