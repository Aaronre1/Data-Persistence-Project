using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    
    public int highScore;
    public string bestPlayer;
    
    public string playerName;
    public int score;

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void SaveScore()
    {
        if (score > highScore)
        {
            highScore = score;
            bestPlayer = playerName;
            
            SaveData data = new SaveData
            {
                highScore = highScore,
                playerName = bestPlayer
            };
            
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }
    
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            highScore = data.highScore;
            bestPlayer = data.playerName;
        }
        
    }
}
