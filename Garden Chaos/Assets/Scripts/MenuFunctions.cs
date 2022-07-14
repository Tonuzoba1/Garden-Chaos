using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject highScore;
    public GameObject credit;

    private void Update()
    {
        if(pauseMenu != null)
        {
            if (pauseMenu.activeSelf == true && Input.GetButtonDown("Cancel"))
            {
                Resume();
            }
            else if (Input.GetButtonDown("Cancel"))
            {
                Pause();
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        PlayerStats.playerLevel = 0;
        PlayerStats.playerPoints = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Credits()
    {
        highScore.SetActive(false);
        credit.SetActive(true);
    }

    public void HighScore()
    {
        credit.SetActive(false);
        highScore.SetActive(true);

    }
}