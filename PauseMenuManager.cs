using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isPaused)
                GoToMainMenu(); 
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); 
        Time.timeScale = 0f;      // freeze game time
        isPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume button clicked"); // Add this

        pauseMenu.SetActive(false); 
        Time.timeScale = 1f;       
        isPaused = false;
    }

    public void GoToMainMenu()
    {
            Debug.Log("Menu button clicked"); // Add this

        Time.timeScale = 1f;        // ensure time scale is reset
        SceneManager.LoadScene("Menu"); 
    }
}
