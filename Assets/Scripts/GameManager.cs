using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    bool gamePaused = false;
    bool gameOver = false;
    [SerializeField] Spaceship player;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    
    [SerializeField] int numEnemies;

    

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameOver == false)
            PauseGame();


    }

    public void StartGame(int nivel)
    {
        SceneManager.LoadScene(nivel);
        Time.timeScale = 1;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
  

    void PauseGame()
    {
        gamePaused = gamePaused ? false : true;

        player.gamePaused = gamePaused;

      

        pauseUI.SetActive(gamePaused);

        Time.timeScale = gamePaused ? 0 : 1;
    }

    public void ReducirNumEnemigos()
    {
        numEnemies --;
        if (numEnemies < 1)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

 
}