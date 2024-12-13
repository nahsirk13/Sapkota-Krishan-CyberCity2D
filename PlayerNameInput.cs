using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private InputField nameInputField;
    [SerializeField] private Button startGameButton; 

    private void Start()
    {
        // disable the start button until a name is entered
        startGameButton.interactable = false;

        // listen for changes in the input field
        nameInputField.onValueChanged.AddListener(OnNameInputChanged);
    }

    private void OnNameInputChanged(string name)
    {
        // enable the button if there's a name
        startGameButton.interactable = !string.IsNullOrEmpty(name);
    }

    public void SavePlayerName()
    {
        // save the name to PlayerPrefs
        PlayerPrefs.SetString("PlayerName", nameInputField.text);
        PlayerPrefs.Save();
        Debug.Log($"Player name saved: {nameInputField.text}");
    }
}
