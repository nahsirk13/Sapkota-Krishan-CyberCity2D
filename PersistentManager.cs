using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PersistentManager : MonoBehaviour
{
    public static PersistentManager Instance;

    public string playerName; // player's name
    public int playerScore=0;   // player's score
    List<string> highScores = new List<string> { };


    private void Awake()
    {
        // Ensure this object persists across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerScore", playerScore);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "Default Player");
        playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
    }

    public void ResetData()
    {
        playerName = "";
        playerScore = 0;
    }

    public void addToHighScores()
    {

    }
}
