using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text scoreText; // reference to UI text

    private void Update()
    {
        int score = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = $"Player: {PlayerPrefs.GetString("PlayerName", "Default")} | Score: {score}";
    }
}