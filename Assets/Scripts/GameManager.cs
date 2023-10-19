using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    [Header("Game States")]
    public bool isPaused; 
    public bool isGameOver; 
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
        
        }
    }

    public void PauseGame()
    {
        isPaused = false;
        Time.timeScale = 0f;
        //this is where your pause menu would go
    }
    public void ResumeGame()
    {
        isPaused = false; 
        Time.timeScale = 1f;
        //this is where you would deactivate your pause menu 
    }
    public void GameOver()
    {
        isGameOver = true;
        //this is where you decide what happens at game over 
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
