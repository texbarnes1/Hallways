using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public FirstPersonController character;

    private void Start()
    {
        GameIsPaused = false;
    }

    void Update()
    {
        if (GameIsPaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        character.m_MouseLook.XSensitivity = 2f;
        character.m_MouseLook.YSensitivity = 2f;
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        character.m_MouseLook.XSensitivity = 0f;
        character.m_MouseLook.YSensitivity = 0f;
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start MenuTest");
    }
    public void LoadOptions()
    {
        
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }


}