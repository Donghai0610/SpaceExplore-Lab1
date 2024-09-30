using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public string sceneName;
    public GameObject pauseMenu;
    public bool isPaused;
    public static PauseMenu instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }

    public void GameResume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void PauseUnPause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

    }
}
