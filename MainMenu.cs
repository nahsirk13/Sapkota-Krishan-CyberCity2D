using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private Button startGameButton;
    [SerializeField] public GameObject mainMenuPanel;
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] public GameObject highScoresPanel;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        startGameButton.interactable = false;

        playerNameInput.onValueChanged.AddListener(OnNameInputChanged);

        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 1f);
        AudioListener.volume = savedVolume;
        volumeSlider.value = savedVolume;

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        highScoresPanel.SetActive(false);

        // check if game has finished and we're returning
        if (PlayerPrefs.GetInt("GameFinished", 0) == 1)
        {
            mainMenuPanel.SetActive(false);
            highScoresPanel.SetActive(true);
            PlayerPrefs.SetInt("GameFinished", 0); // reset the flag
        }
    }

    private void OnNameInputChanged(string name)
    {
        startGameButton.interactable = !string.IsNullOrEmpty(name);
    }

    public void StartGame()
    {
        //PersistentManager.Instance.playerName = playerNameInput.text; 
        //keep name in persistent data
        SceneManager.LoadScene("Level1");
    }

    public void ShowInstructions()
    {
        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ShowHighScores()
    {
        mainMenuPanel.SetActive(false);
        highScoresPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        highScoresPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

    }

    private void OnVolumeChanged(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("GameVolume", volume);
        PlayerPrefs.Save();
    }
}
