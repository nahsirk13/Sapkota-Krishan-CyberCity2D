using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoresManager : MonoBehaviour
{
    [SerializeField] public TMP_Text highScoresText;
    [SerializeField] private GameObject highScoresPanel;
    [SerializeField] private GameObject mainMenuPanel;

    private const int MaxHighScores = 5;


    private void Start()
    {
        highScoresPanel.SetActive(false);
        UpdateHighScoresUI();
    }

    public void ShowHighScores()
    {
        mainMenuPanel.SetActive(false);
        highScoresPanel.SetActive(true);
        UpdateHighScoresUI();

        // Display score from previous scene
        int savedScore = PersistentManager.Instance.playerScore;



    }


    public void BackToMenu()
    {
        highScoresPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }


    private void UpdateHighScoresUI()
    {
        if (highScoresText == null)
        {
            Debug.LogError("HighScoresText is not assigned in the Inspector.");
            return;
        }

        var highScores = LoadHighScores();
        string highScoresString = "High Scores\n\n";
        for (int i = 0; i < highScores.Count; i++)
        {
            highScoresString += $"{i + 1}. {highScores[i].PlayerName} - {highScores[i].Score}\n";
        }
        highScoresText.text = highScoresString;
    }

    private List<HighScoreEntry> LoadHighScores()
    {
        var highScores = new List<HighScoreEntry>();
        for (int i = 0; i < MaxHighScores; i++)
        {
            //string playerName = PersistentManager.Instance.playerName;
            //int score = PersistentManager.Instance.playerScore;
           // if (!string.IsNullOrEmpty(playerName)) 
                //highScores.Add(new HighScoreEntry(playerName, score));
        }
        return highScores;
    }


    private class HighScoreEntry
    {
        public string PlayerName;
        public int Score;

        public HighScoreEntry(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }
    }


}
