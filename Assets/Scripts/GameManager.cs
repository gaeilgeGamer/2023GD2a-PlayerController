using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game States")]
    public bool isPaused;
    public bool isGameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }

        // Other input checks or state checks can go here
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        // Maybe activate a pause menu here
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        // Maybe deactivate a pause menu here
    }

    public void GameOver()
    {
        isGameOver = true;
        // Handle game over logic here, like showing a game over screen
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Replace with your main menu scene name
    }
}
