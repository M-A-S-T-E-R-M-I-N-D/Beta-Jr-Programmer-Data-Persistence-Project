using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM { get; private set; }

    private string playerName;
    private int highscore;
    private string highscoreString;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string highscoreString;
        public int highscore;
    }

    public void FlushScores()
    {
        File.WriteAllText(Application.persistentDataPath + "highscores.json", "{}");
        LoadHighscore();
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highscore = highscore;
        data.highscoreString = highscoreString;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "highscores.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "highscores.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highscore = data.highscore;
            highscoreString = data.highscoreString;
        }
    }

    public void SetName(string name) => playerName = name;

    public string GetName() { return playerName; }

    public void SetHighScore(string scoreString, int score)
    {
        highscoreString = scoreString;
        highscore = score;
    }

    public int GetHighscore() { return highscore; }
    public string GetHighscoreString() { return highscoreString; }

    private void Awake()
    {
        if (GM != null)
        {
            Destroy(gameObject);
            return;
        }

        GM = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
    }
}
