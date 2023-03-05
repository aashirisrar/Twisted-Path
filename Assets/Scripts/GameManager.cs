using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void PauseMenuActive()
    {
        pauseMenu.SetActive(true);
        pauseBtn.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseMenuDeactivate()
    {
        pauseMenu.SetActive(false);
        pauseBtn.SetActive(true);
        Time.timeScale = 1f;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        Time.timeScale = 1f;
    }


    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;    
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1f;
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
        Time.timeScale = 1f;
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level 4");
        Time.timeScale = 1f;
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level 5");
        Time.timeScale = 1f;
    }
}
